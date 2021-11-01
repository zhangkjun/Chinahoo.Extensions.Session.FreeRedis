using FreeRedis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chinahoo.Extensions.Session.FreeRedis
{
    internal static class RedisExtensions
    {
        private const string HmGetScript = (@"return redis.call('HMGET', KEYS[1], unpack(ARGV))");

        internal static object[] HashMemberGet(this RedisClient cache, string key, params string[] members)
        {
            var result = cache.Eval(
                HmGetScript,
                new[] { key },
                GetRedisMembers(members)) as object[];

            // TODO: Error checking?
            return result;
        }

        internal static async Task<object[]> HashMemberGetAsync(
            this RedisClient cache,
            string key,
            params string[] members)
        {

            return await Task.Run(() => cache.Eval(
                 HmGetScript,
                 new[] { key },
                 GetRedisMembers(members)) as object[]);
            // TODO: Error checking?

        }

        private static object[] GetRedisMembers(params string[] members)
        {
            var redisMembers = new object[members.Length];
            for (int i = 0; i < members.Length; i++)
            {
                redisMembers[i] = (object)members[i];
            }

            return redisMembers;
        }
    }
}
