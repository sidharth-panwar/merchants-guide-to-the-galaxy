# Merchant's Guide to the Galaxy

This is my attempt to solve the popular problem with the title name using **SOLID design principles in .Net and C#**. Here's an overview of the application structure:

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
