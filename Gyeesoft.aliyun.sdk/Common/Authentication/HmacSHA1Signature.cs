﻿/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 * 
 * 版权所有 （C）阿里云计算有限公司
 */

using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Aliyun.OSS.Common.Authentication
{
    internal class HmacSha1Signature : ServiceSignature
    {
        private static readonly Encoding Encoding = Encoding.UTF8;
        public override string SignatureMethod
        {
            get { return "HmacSHA1"; }
        }

        public override string SignatureVersion
        {
            get { return "1"; }
        }

        protected override string ComputeSignatureCore(string key, string data)
        {
            Debug.Assert(!string.IsNullOrEmpty(data));

            //using (var algorithm = KeyedHashAlgorithm.Create(SignatureMethod.ToUpperInvariant()))
            //{
            //    algorithm.Key = Encoding.GetBytes(key.ToCharArray());
            //    return Convert.ToBase64String(
            //        algorithm.ComputeHash(Encoding.GetBytes(data.ToCharArray())));
            //}
            using (var hashAlgorithm = new HMACSHA1(Encoding.GetBytes(key.ToCharArray())))
            {
                return Convert.ToBase64String(
                    hashAlgorithm.ComputeHash(Encoding.GetBytes(data.ToCharArray())));
            } 
        }

    }
}
