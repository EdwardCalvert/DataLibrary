# DataLibrary
A data wrapper for Dapper and MySQL, from https://www.youtube.com/watch?v=_JxC6EUxbDo


NuGet package at https://www.nuget.org/packages/EdCalvert.DataLibrary/1.0.0

It offers two methods in the IDataAccess file for all CRUD operations:
```C#
public interface IDataAccess
    {
        Task<List<U>> LoadData<U, T>(string sql, T Parameters, string connectionString);
        Task SaveData<T>(string sql, T Parameters, string connectionString);
    }
```

Stupidly, namespace is ``` DataLibrary```

I would reccomend injecting this as a service, to create loosely coupled service. 


Code sample, from project chili (https://github.com/EdwardCalvert/prRecipieDatabase/blob/DevChannel/BlazorServerApp/RecipeDataLoader/RecipeDataLoader.cs):
```C#
 public async Task InsertSearchQuery(SearchQuery search)
        {
            await _data.SaveData(search.SqlInsertStatement(), search.SqlAnonymousType(), _config.GetConnectionString("recipeDatabase"));
        }

        public async Task<List<SearchQuery>> FindWordsAPISearch(string search)
        {
            return await _data.LoadMultiple<SearchQuery, dynamic>("SELECT * FROM SearchQuery WHERE SearchTerm = @searchTerm", new { searchTerm = search }, _config.GetConnectionString("recipeDatabase"));
        }
```
