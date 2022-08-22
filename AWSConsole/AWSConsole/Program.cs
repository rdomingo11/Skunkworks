using System;
using System.Threading.Tasks;

namespace AWSConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var s3client = new Amazon.S3.AmazonS3Client();
            var buckets = await s3client.ListBucketsAsync();

            foreach (var bucket in buckets.Buckets)
            {
                Console.WriteLine($"Bucket {bucket.BucketName}");

            }

        }
    }
}
