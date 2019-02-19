## Single Field Collisional Cross Section Calculator

The Single Field Collisional Cross Section Calculator integrates directly with Single Field data files that have been acquired and drift calibrated with an Agilent G6560X IM-QTOF instrument. It can then be used to calculate the Collisional Cross Section in Angstroms Squared (&Omega;<sup>2</sup>).

## Background

Currently, in Agilent MassHunter IM-MS Browser there is no option to calculate one-off Collisional Cross Sections. To calculate the Collisional Cross Section the user needs to use Ion Mobility Feature Extraction (IMFE) which will interpret an entire section of a data file via the Feature Finding algorithm - not a quick process.

This application allows a user to browse in a calibrated data file (or the calibration file itself) and using the saved IMS calibration input some basic data such as Drift Time (t<sub>d</sub>), Mass-to-Charge ratio (_m/z_) and Charge State (z) and the (&Omega;<sup>2</sup>) is calculated.

## Getting Started

Download the [latest release of the tool](https://github.com/pageyboy/SingleFieldCCSCalc/releases) and copy the executable to a directory. No installation is required, the application is standalone.

The application may be blocked by Anti-Virus and an exception may need to be raised to run the tool.

Before launching the calculator, ensure that the data file of interest has been calibrated correctly in Agilent MassHunter IM-MS Browser. For assistance, contact your local Agilent support office or refer to your instrument documentation.

## Using The Calculator

On initially launching the calculator you need to choose a data file. The examples below use a file that can be downloaded from the Example Data directory in the repository.

Once the calibrated data file has been chosen the following information should have been populated:

<ul>
    <li>t<sub>fix</sub> Value</li>
    <li>Beta Value</li>
    <li>Drift Gas</li>
</ul>

Once confident that the correct calibration is being utilised the following data should be inputted and the (&Omega;<sup>2</sup>) is calculated:

<ul>
    <li>t<sub>d</sub></li>
    <li><i>m/z</i></li>
    <li>z</li>
</ul>

When all CCS values have been calculated then the results can be exported to a CSV file. The following meta data is also provided in addition to the calculated results:

<ul>
    <li>Date & Time Stamp of Export</li>
    <li>Calculator Version</li>
    <li>IMS Calibration File Path</li>
    <li>t<sub>fix</sub> Value</li>
    <li>Beta Value</li>
</ul>

## Authors

* **Chris Page** - *Initial Work* - [Pageyboy](https://github.com/pageyboy/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/pageyboy/SingleFieldCCSCalc/blob/master/LICENSE.md) file for details
