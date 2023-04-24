# Haversine Distance

C# program to calculate average of Haversine distances.

## Input data
`GenHaversine` will generate the json data in the following format:

```json
{
  "pairs": [
    { "x0": -70.084119, "y0": 117.663007, "x1": -45.568626, "y1": -133.234836 },
    { "x0": -30.775944, "y0": 133.854331, "x1": 1.951451, "y1": -141.883147 },
    { "x0": 36.505496, "y0": 48.363638, "x1": 27.388488, "y1": -32.939023 },
    { "x0": 3.384257, "y0": 124.999125, "x1": 45.483385, "y1": 6.511734 },
    { "x0": -83.028368, "y0": -71.205308, "x1": 31.719903, "y1": -107.754145 },
    { "x0": -62.248424, "y0": -139.93673, "x1": -62.489623, "y1": 94.751006 },
    { "x0": -35.160387, "y0": 110.990575, "x1": 10.259357, "y1": 67.65931 },
    { "x0": -63.542615, "y0": -159.467487, "x1": -62.135455, "y1": 76.246752 },
    { "x0": 33.315041, "y0": -101.33336, "x1": -13.136268, "y1": -107.20179 }
  ]
}
```

Change the value of the `num` variable to specify the number of entries to generate.
The data will be generated inside `data/data_{num}_flex.json`

## Calculate Haversine
`Haversine` will read the input json and calculate and print the average of all the haversine distances between given array of `(x0, y0, x1, y1)` co-ordinates. Additionally it will also print the time taken to read the input and perform the calculation.

```
Result: 10010.714040933892
Input: 3 seconds
Math: 1 seconds
Total: 4 seconds
Throughput: 999999 haversines/seconds
```
