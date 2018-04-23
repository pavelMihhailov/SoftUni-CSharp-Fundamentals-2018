// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
using System.Text;
using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void CheckIfSetWasntSuccessful()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            IPerformer performer = new Performer("ivan", 15);

            ISet set = new Short("izpulnenie");
            stage.AddSet(set);

            IInstrument instrument = new Drums();
            performer.AddInstrument(instrument);

            stage.AddPerformer(performer);

            Assert.That(setController.PerformSets().EndsWith("-- Did not perform"));
        }

        [Test]
        public void PerformSets_ShouldReturnCorrectMessage()
        {
            var stage = new Stage();
            var controller = new SetController(stage);
            
            var set3 = new Long("Long");
            stage.AddSet(set3);

            var perf1 = new Performer("Pesho", 23);
            perf1.AddInstrument(new Guitar());
            var perf3 = new Performer("Gosho", 25);
            perf3.AddInstrument(new Microphone());
            set3.AddPerformer(perf1);
            set3.AddPerformer(perf3);

            var song1 = new Song("6days", new TimeSpan(0, 01, 01));
            var song2 = new Song("Vetrove", new TimeSpan(0, 02, 02));
            var song3 = new Song("Despacito", new TimeSpan(0, 03, 03));
            set3.AddSong(song1);
            set3.AddSong(song2);
            set3.AddSong(song3);

            var expected = new StringBuilder();
            expected.AppendLine("1. Long:");
            expected.AppendLine("-- 1. 6days (01:01)");
            expected.AppendLine("-- 2. Vetrove (02:02)");
            expected.AppendLine("-- 3. Despacito (03:03)");
            expected.AppendLine("-- Set Successful");

            var result = controller.PerformSets();

            Assert.AreEqual(expected.ToString().Trim(), result);
        }

        [Test]
        public void WearDownWorks()
        {
            ISet set = new Short("izpulnenie");
            ISong song = new Song("despacito", new TimeSpan(0, 02, 01));
            set.AddSong(song);

            IPerformer performer = new Performer("ivan", 15);
            IInstrument instrument = new Drums();

            performer.AddInstrument(instrument);

            set.AddPerformer(performer);
            IStage stage = new Stage();
            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            var expected = 80;

            setController.PerformSets();
            
            var actual = instrument.Wear;

            Assert.AreEqual(expected, actual);
        }
    }
}