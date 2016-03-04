using System;
using System.Collections.Generic;
using System.Text;
using BOG.Framework;
using NUnit.Framework;

namespace BOG.Framework
{
    [TestFixture]
    public class FormattingTest
    {
        [Test, Description("KiloToYotta, double == 0.0")]
        public void KiloToYotta_d0()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)0);

            Assert.That(answer == "0", "0.0 == 0");
        }

        [Test, Description("KiloToYotta, long == 0.0")]
        public void KiloToYotta_l0()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)0);

            Assert.That(answer == "0", "0 == 0");
        }

        [Test, Description("KiloToYotta, double == 1.0")]
        public void KiloToYotta_d1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)1);

            Assert.That(answer == "1", "1.0 == 1");
        }

        [Test, Description("KiloToYotta, long == 1")]
        public void KiloToYotta_l1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)1);

            Assert.That(answer == "1", "1 == 1");
        }

        [Test, Description("KiloToYotta, double == 1023.0")]
        public void KiloToYotta_d1023()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)1023);

            Assert.That(answer == "1,023", "1023.0 == 1,023");
        }

        [Test, Description("KiloToYotta, long == 1023")]
        public void KiloToYotta_l1023()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)1023);

            Assert.That(answer == "1,023", "1023 == 1,023");
        }

        [Test, Description("KiloToYotta, double == 1024.0")]
        public void KiloToYotta_d1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)1024);

            Assert.That(answer == "1.0K", "1024.0 == 1.0K");
        }

        [Test, Description("KiloToYotta, long == 1024")]
        public void KiloToYotta_l1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)1024);

            Assert.That(answer == "1.0K", "1024 == 1.0K");
        }

        [Test, Description("KiloToYotta, double == 1024.0 * 1024.0 - 1")]
        public void KiloToYotta_d1024x1024_1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)(1024 * 1024 - 1));

            Assert.That(answer == "1,024.0K", "1024.0 * 1024.0 - 1 == 1,024.0K");
        }

        [Test, Description("KiloToYotta, long == 1024")]
        public void KiloToYotta_l1024x1024_1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)( 1024 * 1024 - 1));

            Assert.That(answer == "1,024.0K", "1024 * 1024 - 1 == 1,024.0K");
        }

        [Test, Description("KiloToYotta, double == 1024.0 * 1024.0")]
        public void KiloToYotta_d1024x1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)(1024 * 1024));

            Assert.That(answer == "1.00M", "1024.0 * 1024.0 == 1.00M");
        }

        [Test, Description("KiloToYotta, long == 1024 * 1024")]
        public void KiloToYotta_l1024x1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)(1024 * 1024));

            Assert.That(answer == "1.00M", "1024.0 * 1024.0 == 1.00M");
        }

        [Test, Description("KiloToYotta, double == 1024.0 * 1024.0 * 1024.0 - 1")]
        public void KiloToYotta_d1024x1024x1024_1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)(1024 * 1024 * 1024 - 1));

            Assert.That(answer == "1,024.00M", "1024.0 * 1024.0 * 1024.0 - 1 == 1,024.00M");
        }

        [Test, Description("KiloToYotta, long == 1024.0 * 1024.0 * 1024.0 - 1")]
        public void KiloToYotta_l1024x1024x1024_1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)(1024 * 1024 * 1024 - 1));

            Assert.That(answer == "1,024.00M", "1024.0 * 1024.0 * 1024.0 - 1 == 1,024.00M");
        }

        [Test, Description("KiloToYotta, double == 1024.0 * 1024.0 * 1024.0")]
        public void KiloToYotta_d1024x1024x1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)(1024.0 * 1024.0 * 1024.0));

            Assert.That(answer == "1.000G", "1024.0 * 1024.0 * 1024.0 == 1.000G");
        }

        [Test, Description("KiloToYotta, long == 1024.0 * 1024.0 * 1024.0")]
        public void KiloToYotta_l1024x1024x1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((long)(1024 * 1024 * 1024));

            Assert.That(answer == "1.000G", "1024 * 1024 * 1024 == 1.000G");
        }

        [Test, Description("KiloToYotta, long == 1024.0 * 1024.0 * 1024.0 * 1024.0 - 1")]
        public void KiloToYotta_d1024x1024x1024x1024_1()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)(1024.0 * 1024.0 * 1024.0 * 1024.0 - 1));

            Assert.That(answer == "1,024.000G", "1024.0 * 1024.0 * 1024.0 * 1024.0 - 1 == 1,024.000G");
        }

        [Test, Description("KiloToYotta, long == 1024.0 * 1024.0 * 1024.0 * 1024.0")]
        public void KiloToYotta_d1024x1024x1024x1024()
        {
            string answer = BOG.Framework.Formatting.KiloToYotta((double)(1024.0 * 1024.0 * 1024.0 * 1024.0));

            Assert.That(answer == "1.000T", "1024.0 * 1024.0 * 1024.0 * 1024.0 == 1.000T");
        }

    }
}
