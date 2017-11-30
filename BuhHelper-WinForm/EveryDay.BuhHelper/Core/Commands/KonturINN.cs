﻿using EveryDay.BuhHelper.Console.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace EveryDay.BuhHelper.Console.Commands
{
    public class KonturINNCommand : ICommandWithDesc
    {
        private string TOKEN => "3208d29d15c507395db770d0e65f3711e40374df";

        public string Name => "inn";

        public string Description => "Введите ИНН (10-12 цифр)";

        public ICommandResult Exec(string arg)
        {
            var result = new CommandResult();

            var url = $"https://focus-api.kontur.ru/api3/req?key={TOKEN}&inn={arg}";

            #region отправка запроса

            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                result.Success = false;
                result.Error = ex.Message;
                return result;
            }
            
            Stream dataStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(dataStream);
            
            string responseFromServer = reader.ReadToEnd();

            reader.Close();

            response.Close();


            #endregion



            var conts = JsonConvert.DeserializeObject<Response[]>(responseFromServer);

            if (conts.Length > 0)
            {
                var cont = conts[0];
                result.Result = $"{cont.UL.LegalName.Full} {cont.UL.Heads[0].Fio}";
                result.Success = true;
            }else
            {
                result.Error = $"Ничего хорошего не найдено";
                result.Success = false;
            }

            return result;
        }
    }
}
