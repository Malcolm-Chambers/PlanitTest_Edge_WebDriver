namespace PlanitTest_Edge_WebDriver.Helpers
{
    public static class LocatorsInContact
    {
        // Magic string should only be stored in one place.  This the place to store strings that are used to locate fields

        public static string SubmitButton { get; set; } = "btn-contact";
        public static string BackButton { get; set; } = "/html/body/div[2]/div/a";
        public static string forename { get; set; } = "forename";
        public static string surname { get; set; } = "surname";
        public static string email { get; set; } = "email";
        public static string telephone { get; set; } = "telephone";
        public static string message { get; set; } = "message";
        public static string forenameLabel { get; set; } = "/html/body/div[2]/div/form/fieldset/div[1]/label";
        public static string forenameHelp { get; set; } = "/html/body/div[2]/div/form/fieldset/div[1]/div/span";
        public static string surnameLabel { get; set; } = "/html/body/div[2]/div/form/fieldset/div[2]/label";
        public static string emailLabel { get; set; } = "/html/body/div[2]/div/form/fieldset/div[3]/label";
        public static string emailHelp { get; set; } = "/html/body/div[2]/div/form/fieldset/div[3]/div/span[1]";
        public static string telephoneLabel { get; set; } = "/html/body/div[2]/div/form/fieldset/div[4]/label";
        public static string telephoneHelp { get; set; } = "/html/body/div[2]/div/form/fieldset/div[4]/div/span[1]";
        public static string messageLabel { get; set; } = "/html/body/div[2]/div/form/fieldset/div[5]/label";
        public static string messageHelp { get; set; } = "/html/body/div[2]/div/form/fieldset/div[5]/div/span";
        public static string AlertCompleted { get; set; } = "/html/body/div[2]/div/div";
        public static string Popup { get; set; } = "/html/body/div[3]";
        public static string SubmittedMessage { get; set; } = "/html/body/div[2]/div/div";
    }
}
