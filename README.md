  <h1>Publication Ad Activity</h1>
  <p>This API returns a list of data about advertisers in a publication (in this case, a magazine or newspaper) with some
additional information about the publication in which the advertiser's advertisements were found.</p>
            <p>Single-page application, built with:</p>
            <ul>
                <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code. Used Dependency Injection as much as possible</li>
                <li>Entity Framework and SQL Server Express LocalDB to persist data from API</li>
                <li><a href='https://facebook.github.io/react/'>React</a>, <a href='http://redux.js.org'>Redux</a>, and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>
                <li><a href='https://webpack.github.io/'>Webpack</a> for building and bundling client-side resources</li>
                <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
            </ul>

<h2>Homepage

![Homepage](https://github.com/edwinyung/adDataWeb/blob/master/adDataWeb/Images/Homepage.png)

   
		

A full list advertisers, including all object data (Month, Publication Id, Publication Name, Parent Company, Parent Company Id, Brand Name, Brand Id, Product Category, Ad Pages and Estimated Print Spend). This list should be sortable and paged with either client-side or server-side code. Default sort should be by brand name alphabetically.</li>
				![FullListofAds-Page1](https://github.com/edwinyung/adDataWeb/blob/master/adDataWeb/Images/FulllistofAds-Page1.png)
				![FullListofAds-Page2](https://github.com/edwinyung/adDataWeb/blob/master/adDataWeb/Images/FulllistofAds-Page2.png)

A list of brands that have at least 2 ad pages, and are considered part of the Toiletries & Cosmetics > Hair Care
product category. This list should also be sortable and paged. Default sort by brand name alphabetically.

![SelectedBrands](https://github.com/edwinyung/adDataWeb/blob/master/adDataWeb/Images/SelectedBrands.png)

The top five Product Categories by estimated spend. Default sort by number of pages (descending), then product category alphabetically.
![SelectedProductCategories](https://github.com/edwinyung/adDataWeb/blob/master/adDataWeb/Images/SelectedProductCategories.png)

The top five Parent Companies by number of pages, then estimated spend during a single month. Keep in mind that a Parent Company may run ads in multiple issues / months. Default sort by number of pages (descending), estimated spend (descending), then Parent Company alphabetically.
![SelectedParentCompanies](https://github.com/edwinyung/adDataWeb/blob/master/adDataWeb/Images/SelectedParentCompanies.png)

		
