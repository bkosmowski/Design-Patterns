using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using MoreLinq;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace DesignPatterns.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class Database : IDatabase
    {
        private readonly Dictionary<string, int> _capitols;

        private Database()
        {
            _capitols = File.ReadAllLines(
                    Path.Combine(
                        new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "Singleton/capitals.txt")
                )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1)));
        }

        private static readonly Lazy<Database> _instance = new Lazy<Database>(() => new Database());

        public static Database Instance = _instance.Value;

        public int GetPopulation(string name) => _capitols[name];
    }
}
