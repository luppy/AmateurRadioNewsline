﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmateurRadioNewsline
{
    struct Segment
    {
        public TimeSpan start;
        public TimeSpan duration;

        public override String ToString()
        {
            return $"{start:hh\\:mm\\:ss} / {duration:ss\\.fff}";
        }
    }


    static class WaveStreamUtils
    {
        public static byte[] ReadAll(this WaveStream input)
        {
            long originalPosition = input.Position;
            input.Position = 0;
            byte[] buffer = new byte[input.Length];
            input.Read(buffer, 0, buffer.Length);
            input.Position = originalPosition;
            return buffer;
        }

        public static List<Segment> Split(this WaveStream input)
        {
            const short Threshold = 256;
            const int MinLength = 882 * 40; // 0.50 s

            byte[] buffer = input.ReadAll();
            double bytesPerSec = input.WaveFormat.AverageBytesPerSecond;

            List<Segment> result = new List<Segment>();

            int start = 0;
            for (int i = 0; i < buffer.Length; i += 2)
            {
                short sample = BitConverter.ToInt16(buffer, i);

                if (Math.Abs(sample) > Threshold)
                {
                    if (i - start >= MinLength)
                    {
                        result.Add(new Segment() { start = TimeSpan.FromSeconds(start / bytesPerSec), duration = TimeSpan.FromSeconds((i - start) / bytesPerSec) });
                    }
                    start = i;
                }
            }

            return result;
        }
    }
}