## Technical considerations
* The project was calling for "a table" and I was not sure what that meant exactly. The simplest thing would be making a small command-line program that outputs a csv file. I have chosen instead to have a small webpage that displays the results.
* There is a limit of requests to the API, while the max page size is 25. This means doing a lot of requests. To go around that, I went with the simplest option of adding a delay between requests to achieve under 100 requests/minute.
* I have also added simple caching (filesystem-based). This was done to avoid making all the calls every time the program is ran, which takes time. In real life, the cache time would probably have to be rethought (it's 1 day now)
* Errors are logged (using log4net)
* I have made the code testable and added an empty tests project. The first thing I would test would be the HouseService: mock the api client to return a static list of results and check whether the aggregation and sorting works corectly.
* Hardest part of the project? Naming. :-) The API output is in Dutch and I wanted to keep my code in English, so I had to make a transition somewhere.
