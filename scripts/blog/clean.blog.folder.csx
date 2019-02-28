void CleanBlogFolder(string root)
{
    var blogDirectory = new DirectoryInfo(
        $"{root}/blog"
    );
    if (blogDirectory.Exists)
    {
        blogDirectory.Delete();
    }
}