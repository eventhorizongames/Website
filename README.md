This is a placeholder site for the EventHorizon Games Studio.
It will be updated to an ASP.NET Core based website in the future.

# TODO
Here are some toDo's for the website

- Convert to ASP.NET Core
- Add Applications Insights for website analytics.
- Add a blog, 
  - As part of the site
  - or as a standalone website
  - 
# Development  

Run jekyll through server to test deployed pages
~~~
docker run --rm --volume="$PWD\:/srv/jekyll" -p 4000:4000 -it jekyll/minimal:pages jekyll serve --watch --incremental --force_polling
~~~