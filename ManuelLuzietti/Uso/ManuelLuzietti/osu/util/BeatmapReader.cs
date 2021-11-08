using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Uso.ManuelLuzietti.osu.model;

namespace Uso.ManuelLuzietti.osu.util
{
    class BeatmapReader
    {

        private List<HitpointImpl> hitPoints;

        private int n;

        private int index = 0;

        private List<string> lines;

        /**
         * Instantiates a new {@link BeatMap} reader.
         *
         * @param in the in
         */
        public BeatmapReader(byte[] data)
        {
            this.lines = ReadAllResourceLines(data).ToList();
            this.SetHitpoints();
        }


        public static class BeatmapOptions
        {
            public static string Hitobjects { get { return "[HitObjects]"; } }
            public static string General { get { return "[General]"; } }
            public static string Editor { get { return "[Editor]"; } }
            public static string Metadata { get { return "[Metadata]"; } }
            public static string Difficulty { get { return "[Difficulty]"; } }
            public static string Events { get { return "[Events]"; } }
            public static string Timingpoints { get { return "[TimingPoints]"; } }
            public static string Colours { get { return "[Colours]"; } }
        }

        /**
         * Sets the hitpoints.
         */
        private void SetHitpoints()
        {
            try
            {
                this.n = FindNumOfLinesToOptions(this.lines,
                        BeatmapOptions.Hitobjects);
            }
            catch (IOException e)
            {
                Console.WriteLine(
                        "Error: stringa \"[HitObjects]\" non presente nella beatmap!");
                Console.WriteLine(e.StackTrace);
            }
            this.hitPoints = this.lines.Skip(n).Where(x => !x.Contains("//")).TakeWhile(x => !x.Equals("")).Select(x =>
            {
                string[] values = x.Split(",");
                return new HitpointImpl(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), Convert.ToDouble(values[2]));
            }).ToList();
        }

        /**
         * Gets the hitpoints.
         *
         * @return the hitpoints
         */
        public List<HitpointImpl> GetHitpoints()
        {
            return this.hitPoints;
        }



        /**
         * Checks for next hitpoint.
         *
         * @return true, if successful
         */
        private bool HasNextHitpoint()
        {
            if (this.hitPoints[index + 1] != null)
            {
                return true;
            }
            else
            {
                this.ResetIndex();
                return false;
            }
        }

        /**
         * Read hitpoint.
         *
         * @return the hit point
         */
        public IHitPoint readHitpoint()
        {
            if (this.HasNextHitpoint())
            {
                index += 1;
                return this.hitPoints[index];
            }
            else
            {
                return null;
            }
        }

        /**
         * Reset index.
         */
        public void ResetIndex()
        {
            this.index = 0;
        }

        /**
         * Find num of lines to options.
         *
         * @param lines the lines
         * @param opt   the options
         * @return the int
         * @throws IOException Signals that an I/O exception has occurred.
         */
        private int FindNumOfLinesToOptions(List<string> lines,
                string opt)
        {
            int count = 0;
            bool flagFound = false;
            foreach (string line in lines)
            {
                // System.out.println(line);
                count += 1;
                if (line.Contains(opt))
                {
                    flagFound = true;
                    break;
                }
            }
            if (flagFound)
            {
                return count;
            }
            else
            {
                throw new IOException();
            }
        }

        /**
         * Gets the option map.
         *
         * @param opt the options
         * @return the option map
         * @throws IOException Signals that an I/O exception has occurred.
         */
        public Dictionary<string, string> GetOptionMap(string opt)
        {
            this.n = FindNumOfLinesToOptions(this.lines, opt);
            Dictionary<string, string> map = this.lines.Skip(this.n).Where(x => !x.Contains("//")).TakeWhile(x => !x.Equals(""))
                    .Select(x => x.Split(":").ToList()).ToDictionary(x => x[0], x => x[1]);
            return map;
        }

        /**
         * Gets the bakground.
         *
         * @return the bakground
         */
        public String GetBakground()
        {
            try
            {
                this.n = FindNumOfLinesToOptions(this.lines, BeatmapOptions.Events);
            }
            catch (IOException e)
            {
                Console.WriteLine(
                        "Error: stringa \"[Events]\" non presente nella beatmap!");
                Console.WriteLine(e.StackTrace);
            }
            return this.lines.Skip(this.n).Where(x => !x.Contains("//")).TakeWhile(x => !x.Equals("")).Select(x =>
            {
                string[] values = x.Split(",");
                return (values.ToList())[2];
            }).ToList()[0].Replace("\"", "");
        }

        /**
         * Gets the starting time.
         *
         * @return the starting time
         */
        public Double GetStartingTime()
        {
            try
            {
                this.n = FindNumOfLinesToOptions(this.lines,
                        BeatmapOptions.Timingpoints);
            }
            catch (IOException e)
            {
                Console.WriteLine(
                        "Error: stringa \"[Events]\" non presente nella beatmap!");
                Console.WriteLine(e.StackTrace);
            }
            double? returnValue = this.lines.Skip(this.n).Take(1).Select(x =>
            {
                return Convert.ToDouble(x.Split(",")[0]);
            }).Aggregate((x, y) => x + y);
        
            if (returnValue == null)
            {
                Console.WriteLine("Missing starting time.");
                throw new Exception();
            }
            else
            {
                return returnValue.Value;
            }
        }

        /**
         * Gets the break times.
         *
         * @return the break times
         */
        public List<List<Double>> getBreakTimes()
        {
            try
            {
                this.n = FindNumOfLinesToOptions(this.lines, BeatmapOptions.Events);
            }
            catch (IOException e)
            {
                Console.WriteLine(
                        "Error: stringa \"[Events]\" non presente nella beatmap!");
                Console.WriteLine(e.StackTrace);
            }
            return this.lines.Skip(this.n).Where(x => !x.Contains("//")).TakeWhile(x => !x.Equals("")).Where(x => x.Split(",")[0].Equals("2")).Select(x =>
              {
                  string[] values = x.Split(",");
                  return values.ToList().GetRange(1, 3).Select(y => Convert.ToDouble(y)).ToList();
              }).ToList();
        }
        public string[] ReadAllResourceLines(byte[] resourceData)
        {
            using (Stream stream = new MemoryStream(resourceData))
            using (StreamReader reader = new StreamReader(stream))
            {
                return EnumerateLines(reader).ToArray();
            }
        }
        public IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    
}
