export interface Country {
    name: string;
}

export interface CountryDto{
    name : string;
    capital : string;
    population : number;
    timezones : string [];
    currencies : CurrencyDto [];
    languages : LanguageDto [];
    borders : string [];
    flag : string;

}

export interface ResponseDto{
        name : string ;
        topLevelDomain : string [] ;
        alpha2Code : string ;
        alpha3Code : string ;
        callingCodes : string [];
        capital : string ;
        altSpellings : string [] ;
        region : string ;
        subregion : string ;
        population : number ;
        latlng : number [] ;
        demonym : string ;
         area : number ;
         gini : number ;
        timezones : string [] ;
        borders : string [];
        nativeName : string ;
        numericCode : string ;
        currencies : CurrencyDto [] ;
         languages : LanguageDto [] ;
         translations : TranslationDto ;
        flag : string ;
         regionalBlocs : RegionalBlocDto [] ;
        cioc : string ;
}

export interface CurrencyDto{
    code : string ;
    name : string ;
    symbol : string ;

}

export interface LanguageDto{

    iso639_1 : string ;
    iso639_2 : string ;
    name : string ;
    nativeName : string ;

}

export interface TranslationDto{
   de : string ;
    es : string ;
   fr : string ;
   ja : string ;
    it : string ;
    br : string ;
    pt : string ;
    nl : string ;
    hr : string ;
    fa : string ;

}



export interface RegionalBlocDto{
     acronym: string;
    name : string;
    otherAcronyms : string [];
    otherNames: string [];
}