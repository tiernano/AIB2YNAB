# AIB2YNAB
AIB2YNAB is a tool for converting [AIB][1] account exports to a format that [YNAB][2] can read and import.

## How To Use

Its a somewhat manual process. Login to AIB Internet banking, select your given account and select historical data. There is an option to export the data as a CSV file.

Run the tool (command line) with the following parameters:

    aib2ynab importfile.csv exportfile.csv
    
This will create or overwrite the exportfile.csv, so make sure its not important!

once completed, open YNAB and select your account, go to file and select 'import from your bank'. Select the file, make sure all looks ok (Dates are in YNAB format, but just make sure!) and click import.

Thats it.

## How To Build

Build with [VS2015 Community Edition][3]. Working on getting it to build on other platforms.

[1]:http://www.aib.ie
[2]:http://www.ynab.com
[3]:https://www.visualstudio.com/products/visual-studio-community-vs
