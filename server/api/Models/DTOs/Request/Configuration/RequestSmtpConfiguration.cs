namespace api.Models.DTOs.Request.Configuration
{
    public class RequestSmtpConfiguration
    {
 


            /// <summary>
            /// Indirizzo IP o nome DNS del server SMTP.
            /// </summary>
            /// <example>sandbox.smtp.mailtrap.io</example>
            public string Server { get; set; }

            /// <summary>
            /// Nome utente per l'autenticazione SMTP.
            /// </summary>
            /// <example>de35ddf5383c06</example>

            public string UserName { get; set; }

            /// <summary>
            /// Porta del server SMTP.
            /// </summary>
            /// <example>587</example>
            public int Port { get; set; }

            /// <summary>
            /// Indirizzo email del mittente.
            /// </summary>
            /// <example>dev@marcatempo.it</example>
            public string SenderEmail { get; set; }

            /// <summary>
            /// Nome del mittente.
            /// </summary>
            /// <example>dev marcatempo</example>
            public string SenderName { get; set; }

            /// <summary>
            /// Password per l'autenticazione SMTP.
            /// </summary>
            /// <example>ff133f4a7a43aa</example>
            public string Password { get; set; }


    }
}
