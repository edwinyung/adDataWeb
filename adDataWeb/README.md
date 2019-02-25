Publication Ad Activity

Single-page application, built with:

1. ASP.NET Core and C# for cross-platform server-side code. Used Dependency Injection as much as possible
2. Entity Framework and SQL Server Express LocalDB to persist data from API
3. React, Redux, and TypeScript for client-side code
4. Webpack for building and bundling client-side resources
5. Bootstrap for layout and styling
6. Azure
7. Docker for targeting Linux distributions
8. Test API method called PublicationAdActivity


This method returns a list of data about advertisers in a publication (in this case, a magazine or newspaper) with some additional information about the publication in which the advertiser's advertisements were found.

A full list advertisers, including all object data (Month, Publication Id, Publication Name, Parent Company, Parent Company Id, Brand Name, Brand Id, Product Category, Ad Pages and Estimated Print Spend). This list should be sortable and paged with either client-side or server-side code. Default sort should be by brand name alphabetically.

A list of brands that have at least 2 ad pages, and are considered part of the Toiletries & Cosmetics > Hair Care product category. This list should also be sortable and paged. Default sort by brand name alphabetically.

The top five Product Categories by estimated spend. Default sort by number of pages (descending), then product category alphabetically.

The top five Parent Companies by number of pages, then estimated spend during a single month. Keep in mind that a Parent Company may run ads in multiple issues / months. Default sort by number of pages (descending), estimated spend (descending), then Parent Company alphabetically.