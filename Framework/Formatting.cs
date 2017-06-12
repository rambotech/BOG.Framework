using System;
using System.Collections.Generic;
using System.Text;

namespace BOG.Framework
{
	/// <summary>
	/// Miscellaneous string formatting methods.
	/// </summary>
	public static class Formatting
	{
		/// <summary>
		/// Changes large values to their less granular kilo, mega, ... yotta equivalent.  Uses 1024 to represent 1K.
		/// </summary>
		/// <param name="number">The value to compress</param>
		/// <returns>1023, 1.0K, 1023.9K, 1.00M, etc.</returns>
		public static string KiloToYotta(double number)
		{
			return KiloToYotta(number, true);
		}

		/// <summary>
		/// Changes large values to their less granular kilo, mega, ... yotta equivalent.  Uses 1024 to represent 1K.
		/// </summary>
		/// <param name="number">The value to compress</param>
		/// <param name="use1024As1K">true for 1024 as 1K, or false for 1000 as 1K</param>
		/// <returns>1023, 1.0K, 1023.9K, 1.00M, etc.</returns>
		public static string KiloToYotta(double number, bool use1024As1K )
		{
			double baseValue = use1024As1K ? 1024.0 : 1000.0;
			string Result;

			if (Math.Abs(number) < baseValue)
				Result = string.Format("{0:#,0}", number);
			else if (Math.Abs(number) < baseValue * baseValue)
				Result = string.Format("{0:#,0.0}K", number / baseValue);
			else if (Math.Abs(number) < baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.00}M", number / (baseValue * baseValue));
			else if (Math.Abs(number) < baseValue * baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.000}G", number / (baseValue * baseValue * baseValue));
			else if (Math.Abs(number) < baseValue * baseValue * baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.000}T", number / (baseValue * baseValue * baseValue * baseValue));
			else if (Math.Abs(number) < baseValue * baseValue * baseValue * baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.000}P", number / (baseValue * baseValue * baseValue * baseValue * baseValue));
			else if (Math.Abs(number) < baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.000}E", number / (baseValue * baseValue * baseValue * baseValue * baseValue * baseValue));
			else if (Math.Abs(number) < baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.000}Z", number / (baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue));
			else if (Math.Abs(number) < baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue)
				Result = string.Format("{0:#,0.000}Y", number / (baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue * baseValue));
			else
				Result = string.Format("{0:#,0}", number);

			return Result;
		}

		/// <summary>
		/// Changes large values to their less granular kilo, mega, ... yotta equivalent.
		/// </summary>
		/// <param name="number">The value to compress</param>
		/// <returns>1023, 1.0K, 1023.9K, 1.00M, etc.</returns>
		public static string KiloToYotta(long number)
		{
			return KiloToYotta((double) number, true);
		}

		/// <summary>
		/// Changes large values to their less granular kilo, mega, ... yotta equivalent.
		/// </summary>
		/// <param name="number">The value to compress</param>
		/// <param name="use1024As1K">true for 1024 as 1K, or false for 1000 as 1K</param>
		/// <returns>1023, 1.0K, 1023.9K, 1.00M, etc.</returns>
		public static string KiloToYotta(long number, bool use1024As1K)
		{
			return KiloToYotta((double) number, use1024As1K);
		}

		private static string[] _ones =
		{
			"zero",
			"one",
			"two",
			"three",
			"four",
			"five",
			"six",
			"seven",
			"eight",
			"nine"
		};

		private static string[] _teens =
		{
			"ten",
			"eleven",
			"twelve",
			"thirteen",
			"fourteen",
			"fifteen",
			"sixteen",
			"seventeen",
			"eighteen",
			"nineteen"
		};

		private static string[] _tens =
		{
			"",
			"ten",
			"twenty",
			"thirty",
			"forty",
			"fifty",
			"sixty",
			"seventy",
			"eighty",
			"ninety"
		};

		// US Nnumbering:
		private static string[] _thousands =
		{
			"",
			"thousand",
			"million",
			"billion",
			"trillion",
			"quadrillion"
		};

		/// <summary>
		/// Converts a numeric value to words suitable for the portion of
		/// a check that writes out the amount.
		/// </summary>
		/// <param name="value">Value to be converted</param>
		/// <returns>string.  Example: 147.57 becomes "One hundred forty-seven and 57/100"</returns>
		public static string CurrencyWrittenAmount(decimal value)
		{
			string digits, temp;
			bool showThousands = false;

			// Use StringBuilder to build result
			StringBuilder builder = new StringBuilder();
			// Convert integer portion of value to string
			digits = ((long) value).ToString();
			// Traverse characters in reverse order
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				int ndigit = (int) (digits[i] - '0');
				int column = (digits.Length - (i + 1));

				// Determine if ones, tens, or hundreds column
				switch (column % 3)
				{
					case 0:        // Ones position
						showThousands = true;
						if (i == 0)
						{
							// First digit in number (last in loop)
							temp = String.Format("{0} ", _ones[ndigit]);
						}
						else if (digits[i - 1] == '1')
						{
							// This digit is part of "teen" value
							temp = String.Format("{0} ", _teens[ndigit]);
							// Skip tens position
							i--;
						}
						else if (ndigit != 0)
						{
							// Any non-zero digit
							temp = String.Format("{0} ", _ones[ndigit]);
						}
						else
						{
							// This digit is zero. If digit in tens and hundreds
							// column are also zero, don't show "thousands"
							temp = String.Empty;
							// Test for non-zero digit in this grouping
							if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
								showThousands = true;
							else
								showThousands = false;
						}

						// Show "thousands" if non-zero in grouping
						if (showThousands)
						{
							if (column > 0)
							{
								temp = String.Format("{0}{1}{2}",
									temp,
									_thousands[column / 3],
								//allZeros ? " " : ", ");
								" ");
							}
							// Indicate non-zero digit encountered
						}
						builder.Insert(0, temp);
						break;

					case 1:        // Tens column
						if (ndigit > 0)
						{
							temp = String.Format("{0}{1}",
								_tens[ndigit],
								(digits[i + 1] != '0') ? "-" : " ");
							builder.Insert(0, temp);
						}
						break;

					case 2:        // Hundreds column
						if (ndigit > 0)
						{
							temp = String.Format("{0} hundred ", _ones[ndigit]);
							builder.Insert(0, temp);
						}
						break;
				}
			}

			// Append fractional portion/cents
			builder.AppendFormat("and {0:00}/100", (value - (long) value) * 100);

			// Capitalize first letter
			return String.Format("{0}{1}",
				Char.ToUpper(builder[0]),
				builder.ToString(1, builder.Length - 1));
		}
	}
}
