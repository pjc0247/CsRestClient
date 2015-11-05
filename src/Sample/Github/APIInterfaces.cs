﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsRestClient;
using CsRestClient.Attributes;

namespace Sample.Github
{
    [AutoHttpMethod]
    public interface APIBase
    {
        string authString { get; set; }
    }

    public interface UserAPI : APIBase
    {
        [Resource("gists")]
        string GetGists();

        [Resource("repos")]
        string GetRepos();
    }

    [AutoHttpMethod]
    [Service("repos")]
    public interface RepoAPI : APIBase
    {
        string owner { get; set; }
        string name { get; set; }

        string GetReadme();
    }
    [Service("gists")]
    public interface GistAPI : APIBase
    {
        string id { get; set; }

        [Resource("")]
        string Get();
        [Resource("")]
        string Get([Suffix]string revision);

        [Put]
        [Resource("star")]
        string Start();
        [Put]
        [Resource("star")]
        string Unstart();
    }
}
