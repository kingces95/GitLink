﻿using System;
using System.Text.RegularExpressions;
using GitTools.Git;

namespace GitLink.Providers {
    public sealed class CustomRawUrlProvider : ProviderBase {
        private readonly Regex _regex = new Regex(@"https?://.+");

        private string _rawUrl;

        public CustomRawUrlProvider()
            : base(new GitPreparer()) {
        }

        public override string RawGitUrl {
            get {
                return _rawUrl;
            }
        }

        public override bool Initialize(string url) {
            if (string.IsNullOrEmpty(url) || !_regex.IsMatch(url)) {
                return false;
            }

            _rawUrl = url;
            if (_rawUrl.EndsWith("/", StringComparison.Ordinal)) {
                _rawUrl = _rawUrl.TrimEnd('/');
            }

            return true;
        }
    }
}
