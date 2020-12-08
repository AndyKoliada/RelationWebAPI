export class Relation{
    constructor(
        public Id: string = null,
        public Name: string = "",
        public FullName: string = "",
        public TelephoneNumber: string = "",
        public EMailAddress: string = "",
        public DefaultCountry: string = "",
        public DefaultCity: string = "",
        public DefaultStreet: string = "",
        public DefaultPostalCode: string = "",
        public StreetNumber: string = "") { }
}