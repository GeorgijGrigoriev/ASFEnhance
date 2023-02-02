﻿using ArchiSteamFarm.Steam;
using ArchiSteamFarm.Steam.Integration;
using ASFEnhance.Data;
using static ASFEnhance.Utils;

namespace ASFEnhance.Friend
{
    internal static class WebRequest
    {
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="steamId"></param>
        /// <returns></returns>
        internal static async Task<(ulong, AjaxAddFriendResponse?)> SendFriendRequest(Bot bot, ulong steamId)
        {
            Uri request = new(SteamCommunityURL, $"/actions/AddFriendAjax");

            Dictionary<string, string> data = new(3) {
                {"steamid", steamId.ToString()},
                {"accept_invite", "0"},
            };

            var response = await bot.ArchiWebHandler.UrlPostToJsonObjectWithSession<AjaxAddFriendResponse>(request, data: data, referer: SteamCommunityURL, session: ArchiWebHandler.ESession.CamelCase).ConfigureAwait(false);
            return (steamId, response?.Content);
        }

        /// <summary>
        /// 验证个人资料链接
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static async Task<ulong?> GetSteamIdByProfileLink(Bot bot, string path)
        {
            Uri request = new(SteamCommunityURL, path);

            var response = await bot.ArchiWebHandler.UrlGetToHtmlDocumentWithSession(request).ConfigureAwait(false);

            return HtmlParser.ParseProfilePage(response);
        }
    }
}