using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Common.Configuration
{
    public static class AppSetting
    {
        private static IConfiguration? _appConfiguration;
        public static IConfiguration AppConfiguration
        {
            get
            {
                if (_appConfiguration == null)
                    throw new NullReferenceException(nameof(_appConfiguration));
                return _appConfiguration;
            }
        }

        public static void Configure(IConfiguration? configuration)
        {
            if (_appConfiguration != null)
            {
                throw new Exception($"设置{nameof(AppConfiguration)}不可修改！！");
            }

            _appConfiguration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }

        /// <summary>
        /// 允许跨域请求列表
        /// </summary>
        public static string[] AllowCors => AppConfiguration.GetSection("AllowCors").Get<string[]>()!;

        /// <summary>
        /// Jwt 配置
        /// </summary>
        public static class Jwt
        {
            public static string SecretKey => AppConfiguration["Jwt:sign"]!;
            public static string Issuer => AppConfiguration["Jwt:iss"]!;
            public static string Audience=> AppConfiguration["Jwt:aud"]!;
             
        }

        /// <summary>
        /// 记录请求
        /// </summary>
        public static class RecordRequest
        {
            public static bool IsEnabled => AppConfiguration.GetValue<bool>("RecordRequest:IsEnabled");
            public static bool IsSkipGetMethod => AppConfiguration.GetValue<bool>("RecordRequest:IsSkipGetMethod");
        }

    }


}
