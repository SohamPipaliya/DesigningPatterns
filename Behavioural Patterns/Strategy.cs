using System;

namespace DesigningPatterns.Behavioural_Patterns
{
    class Strategy
    {
        static void Main(string[] args)
        {
            CompressionContext ctx = new CompressionContext(new ZipCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            ctx.SetStrategy(new RarCompression()); //changed to rar from zip
            ctx.CreateArchive("DotNetDesignPattern");

            Console.ReadLine();
        }
    }

    public interface ICompression
    {
        void CompressFolder(string compressedArchiveFileName);
    }

    public class RarCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using Rar approach: '" + compressedArchiveFileName + ".rar' file is created");
        }
    }

    public class ZipCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using zip approach: '" + compressedArchiveFileName + ".zip' file is created");
        }
    }

    public class CompressionContext
    {
        private ICompression Compression;

        public CompressionContext(ICompression Compression)
        {
            this.Compression = Compression;
        }

        public void SetStrategy(ICompression Compression)
        {
            this.Compression = Compression;
        }

        public void CreateArchive(string compressedArchiveFileName)
        {
            Compression.CompressFolder(compressedArchiveFileName);
        }
    }
}
