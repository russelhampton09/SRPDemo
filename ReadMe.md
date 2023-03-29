# How to Run #

https://learn.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-7.0&tabs=netcore-cli

You can run the app with the dotnet CLI or by installing visual studio 2022 community edition. Installing visual studio community edition is probably easier. When running for the first time it will install node modules and take a moment.

If you do choose the CLI, that link is the best description.



# Modules and Features #

## SRP.OpenLibrary ##

SRP.OpenLibrary is the nuget package I wrote to completely encapsulate the calls made to Open Library API.
- Unit tested
- Completely encapsulates Open Library API, there are no references to the third party API anywhere else in the app
- Follows the nuget plugin pattern as laid out by dotnet, which essentially is just a helper IServicable extension. 
- Can be added to any code base in one line: builder.Services.AddMyLibraryService();
- Uses persistant HTTP client pools to make subsequent calls faster and easier.
- JSON parsing and Factory method generator

## SRPDemo ##

SRPDemo is the back end API. It has a single endpoint, HTTP GET, which expects a page number and a title string.
- Versioned API
- Use of Adapter pattern to fully segregate controller code from Open Library API specific code.

## React front end ##

I chose React for the front end. Features include
- Debounced search bar. Searches are fired when typing has stopped for a few moments, and not during each character typed
- Paginated datatable
- Efficient refreshing of dom elements using hooks


# Known short comings #

Open Library API returns both the total number of matches as an integer count as well as the full json load for the first 100 results.
Known the full number of matches allows fine tuned pagination on the front end, and subsequent results can be seen using the optional parameter "offset" in the Open Library search endpoint.
I didn't have time to implement this.


# Diagram #

A small diagram of the code can be found labeled "diagram" in the same folder this ReadMe is located in.

# Picture of UI #

![alt text](https://github.com/russelhampton09/SRPDemo/blob/main/pic.png)
