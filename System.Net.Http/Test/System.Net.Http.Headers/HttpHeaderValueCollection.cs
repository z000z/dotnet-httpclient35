//
// HttpHeaderValueCollectionTest.cs
//
// Authors:
//	Marek Safar  <marek.safar@gmail.com>
//
// Copyright (C) 2011 Xamarin Inc (http://www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoTests.System.Net.Http.Headers
{
	[TestClass]
	public class HttpHeaderValueCollectionTest
	{
		[TestMethod]
		public void ParseAdd ()
		{
			HttpRequestMessage message = new HttpRequestMessage ();
			HttpRequestHeaders headers = message.Headers;

			headers.TE.ParseAdd ("pp");
			Assert.AreEqual ("pp", headers.TE.ToArray ()[0].Value, "#1");
			Assert.AreEqual (1, headers.TE.Count);
		}

		[TestMethod]
		public void ParseAdd_Invalid ()
		{
			HttpRequestMessage message = new HttpRequestMessage ();
			HttpRequestHeaders headers = message.Headers;

			try {
				headers.Via.ParseAdd ("pp");
			} catch (FormatException) {
			}
		}

		[TestMethod]
		public void TryParseAdd ()
		{
			HttpRequestMessage message = new HttpRequestMessage ();
			HttpRequestHeaders headers = message.Headers;

			Assert.IsTrue (headers.TE.TryParseAdd ("pp"), "#1");
			Assert.AreEqual ("pp", headers.TE.ToArray ()[0].Value, "#2");
			Assert.AreEqual (1, headers.TE.Count, "#3");

			Assert.IsFalse (headers.Via.TryParseAdd ("wrong"), "#4");
		}

		[TestMethod]
		public void ToStringTest ()
		{
			HttpRequestMessage message = new HttpRequestMessage ();
			HttpRequestHeaders headers = message.Headers;

			Assert.AreEqual ("", headers.Connection.ToString (), "#1");

			headers.Connection.Add ("kk");

			Assert.AreEqual ("kk", headers.Connection.ToString (), "#2");

			headers.Connection.Add ("ttt");

			Assert.AreEqual ("kk, ttt", headers.Connection.ToString (), "#3");
		}
	}
}
