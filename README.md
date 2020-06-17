# Merchant's Guide to the Galaxy

This is my attempt to solve the popular problem with the title name using **SOLID design principles in .Net and C#**. Here's an overview of the application structure:

## Problem Description
A merchant buys and sells items in the galaxy. Buying and selling over the galaxy requires you to convert numbers and units. The numbers used for intergalactic transactions follows similar convention to the roman numerals. Roman numerals are based on seven symbols:
<pre><code>I 1
V 5
X 10
L 50
C 100
D 500
m 1000
</code></pre>
Numbers are formed by combining symbols together and adding the values. For example, MMVI is 1000 + 1000 + 5 + 1 = 2006. Generally, symbols are placed in order of value, starting with the largest values. When smaller values precede larger values, the smaller values are subtracted from the larger values, and the result is added to the total. For example MCMXLIV = 1000 + (1000 − 100) + (50 − 10) + (5 − 1) = 1944.

The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more. (They may appear four times if the third and fourth are separated by a smaller value, such as XXXIX.) "D", "L", and "V" can never be repeated. "I" can be subtracted from "V" and "X" only. "X" can be subtracted from "L" and "C" only. "C" can be subtracted from "D" and "M" only. "V", "L", and "D" can never be subtracted. Only one small-value symbol may be subtracted from any large-value symbol. A number written in [16]Arabic numerals can be broken into digits. For example, 1903 is composed of 1, 9, 0, and 3. To write the Roman numeral, each of the non-zero digits should be treated separately. Inthe above example, 1,000 = M, 900 = CM, and 3 = III. Therefore, 1903 = MCMIII. Input to your program consists of lines of text detailing your notes on the conversion between intergalactic units and roman numerals. You are expected to handle invalid queries appropriately.

## Solution Overview
The MerchantApp solution contains two projects:
1. MerchantApp - This project contains all the classes which are used to achieve the Roman to Decimal conversions.
2. MerchantAppTest - This is an MSTest project which uses the MerchantApp reference and tests it's various functionalities.

## How to run the app?
1. Build the solution.
2. Go to the MerchantApp project folder.
3. Update the input.txt update input data.
4. Open console and go to MerchantApp/bin/Debug
5. Type: MerchantApp ..\..\input.txt

## How to run the tests?
1. Open the MerchantApp solution.
2. Build the solution.
3. In Visual Studio, go to Test -> Run -> All Tests.

## Solution Design Overview
1. Shared - All the interfaces and reusable components are kept in the shared folder.
2. Roman - Contains all the logic required for Roman to Decimal conversion.
   - Roman/Rules - Contains the Rules that need to checked to ensure that the Roman Numeral to be converted is a correct numeral.
   - Roman/Expressions - As Input, we can give different kind of expressions to the program to parse. These are as follows:
     - Alias - glob is I - This is basically an alias expression where we are setting an alternate name for the Roman Numeral I. Note that as of now the program doesn't support complex aliases like 'glob is IX'.
     - Alias Question - How much is glob glob? - This is basically a question which reqires evaluating the Roman Numeral using already set aliases.
     - Unit - pish glob Iron is 7020 Credits - This is similar to Alias in that here we are setting up the per unit price of a commodity (Iron) after calculating the alias and given credits.
     - Unit Question - how many Credits is glob prok Silver ? - This requires evaluating already set commodity and aliases to give the answer.

## Additional Class Descriptions
1. ExpressionParser - Evaluates each line provided by the user against the available expressions to see if it matches any of them. If yes then it executes that expression.
2. ExpressionValidationHelper - Utility class for reusable code.
3. Roman - Definition of Roman Numerals.
4. RomanToDecimalFactory - Factory that creates object used for Roman to Decimal conversions.
