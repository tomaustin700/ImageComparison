using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using ImageComparison;

namespace ImageComparison.Tests
{
    [TestClass]
    public class ImageToolTests
    {
        [TestMethod]
        public void SameImageGenerates0PercDifference_GetPercentageDifference_BeTrue()
        {
            string codebase = Assembly.GetExecutingAssembly().Location;
            var exeFolder = new DirectoryInfo(Path.GetDirectoryName(codebase));
            var projectFolder = exeFolder.Parent.Parent.Parent;
            var sampleImages =  new DirectoryInfo(Path.Combine(projectFolder.FullName, "SampleImages"));
            ImageTool.GetPercentageDifference(Path.Combine(sampleImages.FullName, "firefox1.png"), Path.Combine(sampleImages.FullName, "firefox1.png")).Should().Be(0);
        }

        [TestMethod]
        public void SlightlyDifferentImageGeneratesPartialDifference_GetPercentageDifference_BeTrue()
        {
            string codebase = Assembly.GetExecutingAssembly().Location;
            var exeFolder = new DirectoryInfo(Path.GetDirectoryName(codebase));
            var projectFolder = exeFolder.Parent.Parent.Parent;
            var sampleImages = new DirectoryInfo(Path.Combine(projectFolder.FullName, "SampleImages"));
            ImageTool.GetPercentageDifference(Path.Combine(sampleImages.FullName, "img_one.png"), Path.Combine(sampleImages.FullName, "img_two.png")).Should().Be((float)0.69140625);
        }

        [TestMethod]
        public void CompletelyDifferentImageGenerates100PercDifference_GetPercentageDifference_BeTrue()
        {
            string codebase = Assembly.GetExecutingAssembly().Location;
            var exeFolder = new DirectoryInfo(Path.GetDirectoryName(codebase));
            var projectFolder = exeFolder.Parent.Parent.Parent;
            var sampleImages = new DirectoryInfo(Path.Combine(projectFolder.FullName, "SampleImages"));
            ImageTool.GetPercentageDifference(Path.Combine(sampleImages.FullName, "black.png"), Path.Combine(sampleImages.FullName, "white.png")).Should().Be(1);
        }
    }
}