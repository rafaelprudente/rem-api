clear

$baseUri = "https://localhost:44351"

function Add-WorldRegion([string]$name) {
    $Body = @{ name = $name }
    $JsonBody = $Body | ConvertTo-Json
    $Params = @{
        Method = "Post"
        Uri = "$baseUri/api/WorldRegion"
        Body = $JsonBody 
        ContentType = "application/json"
    }
    Invoke-RestMethod @Params
}

function Add-CurrencyCode([string]$name, [string]$characterCode, [long]$numericCode, [int]$decimalPlaces) {
    $Body = @{ name = $name 
               characterCode = $characterCode 
               numericCode = $numericCode 
               decimalPlaces = $decimalPlaces }
    $JsonBody = $Body | ConvertTo-Json
    $Params = @{
        Method = "Post"
        Uri = "$baseUri/api/CurrencyCode"
        Body = $JsonBody 
        ContentType = "application/json"
    }
    Invoke-RestMethod @Params
}

function Add-Country([string]$name, [double]$netToGrossRatio, [long]$worldRegion) {
    $WorldRegionObject = @{ id = $worldRegion }

    $Body = @{ name = $name 
               netToGrossRatio = $netToGrossRatio 
               worldRegion = $WorldRegionObject }
    $JsonBody = $Body | ConvertTo-Json
    $Params = @{
        Method = "Post"
        Uri = "$baseUri/api/Country"
        Body = $JsonBody 
        ContentType = "application/json"
    }
    Invoke-RestMethod @Params
}

function Add-Company([string]$name) {
    $Body = @{ name = $name }
    $JsonBody = $Body | ConvertTo-Json
    $Params = @{
        Method = "Post"
        Uri = "$baseUri/api/Company"
        Body = $JsonBody 
        ContentType = "application/json"
    }
    Invoke-RestMethod @Params
}

Add-WorldRegion "Africa"
Add-WorldRegion "Asia"
Add-WorldRegion "Central America"
Add-WorldRegion "Eastern Europe"
Add-WorldRegion "European Union"
Add-WorldRegion "Middle East"
Add-WorldRegion "North America"
Add-WorldRegion "Oceania"
Add-WorldRegion "South America"
Add-WorldRegion "Caribbean"

Write-Host

Add-CurrencyCode "Albanian Lek" "ALL" 8 2
Add-CurrencyCode "Algerian Dinar" "DZD" 12 2
Add-CurrencyCode "Argentine Peso" "ARS" 32 2
Add-CurrencyCode "Australian Dollar" "AUD" 36 2
Add-CurrencyCode "Bahamian Dollar" "BSD" 44 2
Add-CurrencyCode "Bahraini Dinar" "BHD" 48 3
Add-CurrencyCode "Bangladeshi Taka" "BDT" 50 2
Add-CurrencyCode "Armenian Dram" "AMD" 51 0
Add-CurrencyCode "Barbados Dollar" "BBD" 52 2
Add-CurrencyCode "Bermudian Dollar" "BMD" 60 2
Add-CurrencyCode "Boliviano" "BOB" 68 2
Add-CurrencyCode "Botswana Pula" "BWP" 72 2
Add-CurrencyCode "Belize Dollar" "BZD" 84 2
Add-CurrencyCode "Solomon Islands Dollar" "SBD" 90 2
Add-CurrencyCode "Brunei Dollar" "BND" 96 2
Add-CurrencyCode "Myanmar Kyat" "MMK" 104 0
Add-CurrencyCode "Burundian Franc" "BIF" 108 0
Add-CurrencyCode "Cambodian Riel" "KHR" 116 0
Add-CurrencyCode "Canadian Dollar" "CAD" 124 2
Add-CurrencyCode "Cape Verdean Escudo" "CVE" 132 0
Add-CurrencyCode "Cayman Islands Dollar" "KYD" 136 2
Add-CurrencyCode "Sri Lankan Rupee" "LKR" 144 2
Add-CurrencyCode "Chilean Peso" "CLP" 152 0
Add-CurrencyCode "Chinese Yuan" "CNY" 156 1
Add-CurrencyCode "Chinese Yuan" "COP" 170 0
Add-CurrencyCode "Comoro Franc" "KMF" 174 0
Add-CurrencyCode "Costa Rican Colon" "CRC" 188 2
Add-CurrencyCode "Croatian Kuna" "HRK" 191 2
Add-CurrencyCode "Cuban Peso" "CUP" 192 2
Add-CurrencyCode "Czech Koruna" "CZK" 203 2
Add-CurrencyCode "Danish Krone" "DKK" 208 2
Add-CurrencyCode "Dominican Peso" "DOP" 214 2
Add-CurrencyCode "Salvadoran Colon" "SVC" 222 2
Add-CurrencyCode "Ethiopian Birr" "ETB" 230 2
Add-CurrencyCode "Eritrean Nakfa" "ERN" 232 2
Add-CurrencyCode "Falkland Islands Pound" "FKP" 238 2
Add-CurrencyCode "Fiji Dollar" "FJD" 242 2
Add-CurrencyCode "Djiboutian Franc" "DJF" 262 0
Add-CurrencyCode "Gambian Dalasi" "GMD" 270 2
Add-CurrencyCode "Gibraltar Pound" "GIP" 292 2
Add-CurrencyCode "Guatemalan Quetzal" "GTQ" 320 2
Add-CurrencyCode "Guinean Franc" "GNF" 324 0
Add-CurrencyCode "Guyanese Dollar" "GYD" 328 2
Add-CurrencyCode "Haitian Gourde" "HTG" 332 2
Add-CurrencyCode "Honduran Lempira" "HNL" 340 2
Add-CurrencyCode "Hong Kong Dollar" "HKD" 344 2
Add-CurrencyCode "Hungarian Forint" "HUF" 348 2
Add-CurrencyCode "Icelandic Krona" "ISK" 352 0
Add-CurrencyCode "Indian Rupee" "INR" 356 2
Add-CurrencyCode "Indonesian Rupiah" "IDR" 360 0
Add-CurrencyCode "Iranian Rial" "IRR" 364 0
Add-CurrencyCode "Iraqi Dinar" "IQD" 368 0
Add-CurrencyCode "Israeli New Shekel" "ILS" 376 2
Add-CurrencyCode "Jamaican Dollar" "JMD" 388 2
Add-CurrencyCode "Japanese Yen" "JPY" 392 0
Add-CurrencyCode "Kazakhstani Tenge" "KZT" 398 2
Add-CurrencyCode "Jordanian Dinar" "JOD" 400 3
Add-CurrencyCode "Kenyan Shilling" "KES" 404 2
Add-CurrencyCode "North Korean Won" "KPW" 408 0
Add-CurrencyCode "South Korean Won" "KRW" 410 0
Add-CurrencyCode "Kuwaiti Dinar" "KWD" 414 3
Add-CurrencyCode "Kyrgyzstani Som" "KGS" 417 2
Add-CurrencyCode "Lao Kip" "LAK" 418 0
Add-CurrencyCode "Lebanese Pound" "LBP" 422 0
Add-CurrencyCode "Lesotho Loti" "LSL" 426 2
Add-CurrencyCode "Lesotho Loti" "LVL" 428 2
Add-CurrencyCode "Liberian Dollar" "LRD" 430 2
Add-CurrencyCode "Libyan Dinar" "LYD" 434 3
Add-CurrencyCode "Lesotho Loti" "LTL" 440 2
Add-CurrencyCode "Macanese Pataca" "MOP" 446 1
Add-CurrencyCode "Malawian Kwacha" "MWK" 454 2
Add-CurrencyCode "Malaysian Ringgit" "MYR" 458 2
Add-CurrencyCode "Maldivian Rufiyaa" "MVR" 462 2
Add-CurrencyCode "Macanese Pataca" "MRO" 478 0.7
Add-CurrencyCode "Mauritian Rupee" "MUR" 480 2
Add-CurrencyCode "Mexican Peso" "MXN" 484 2
Add-CurrencyCode "Mongolian Togrog" "MNT" 496 2
Add-CurrencyCode "Moldovan Leu" "MDL" 498 2
Add-CurrencyCode "Moroccan Dirham" "MAD" 504 2
Add-CurrencyCode "Omani Rial" "OMR" 512 3
Add-CurrencyCode "Namibian Dollar" "NAD" 516 2
Add-CurrencyCode "Nepalese Rupee" "NPR" 524 2
Add-CurrencyCode "Netherlands Antillean Guilder" "ANG" 532 2
Add-CurrencyCode "Aruban Florin" "AWG" 533 2
Add-CurrencyCode "Vanuatu Vatu" "VUV" 548 0
Add-CurrencyCode "New Zealand Dollar" "NZD" 554 2
Add-CurrencyCode "Nicaraguan Cordoba" "NIO" 558 2
Add-CurrencyCode "Nigerian Naira" "NGN" 566 2
Add-CurrencyCode "Norwegian Krone" "NOK" 578 2
Add-CurrencyCode "Pakistani Rupee" "PKR" 586 2
Add-CurrencyCode "Panamanian Balboa" "PAB" 590 2
Add-CurrencyCode "Papua New Guinean Kina" "PGK" 598 2
Add-CurrencyCode "Paraguayan Guarani" "PYG" 600 0
Add-CurrencyCode "Peruvian Sol" "PEN" 604 2
Add-CurrencyCode "Philippine Peso" "PHP" 608 2
Add-CurrencyCode "Qatari Riyal" "QAR" 634 2
Add-CurrencyCode "Russian Ruble" "RUB" 643 2
Add-CurrencyCode "Rwandan Franc" "RWF" 646 0
Add-CurrencyCode "Saint Helena Pound" "SHP" 654 2
Add-CurrencyCode "Saudi Riyal" "SAR" 682 2
Add-CurrencyCode "Seychelles Rupee" "SCR" 690 2
Add-CurrencyCode "Sierra Leonean Leone" "SLL" 694 0
Add-CurrencyCode "Singapore Dollar" "SGD" 702 2
Add-CurrencyCode "Vietnamese Dong" "VND" 704 0
Add-CurrencyCode "Somali Shilling" "SOS" 706 2
Add-CurrencyCode "South African Rand" "ZAR" 710 2
Add-CurrencyCode "Swazi Lilangeni" "SZL" 748 2
Add-CurrencyCode "Swedish Krona" "SEK" 752 2
Add-CurrencyCode "Swiss Franc" "CHF" 756 2
Add-CurrencyCode "Syrian Pound" "SYP" 760 2
Add-CurrencyCode "Thai Baht" "THB" 764 2
Add-CurrencyCode "Tongan Paanga" "TOP" 776 2
Add-CurrencyCode "Trinidad And Tobago Dollar" "TTD" 780 2
Add-CurrencyCode "United Arab Emirates Dirham" "AED" 784 2
Add-CurrencyCode "Tunisian Dinar" "TND" 788 3
Add-CurrencyCode "Ugandan Shilling" "UGX" 800 0
Add-CurrencyCode "Macedonian Denar" "MKD" 807 2
Add-CurrencyCode "Egyptian Pound" "EGP" 818 2
Add-CurrencyCode "Pound Sterling" "GBP" 826 2
Add-CurrencyCode "Tanzanian Shilling" "TZS" 834 2
Add-CurrencyCode "United States Dollar" "USD" 840 2
Add-CurrencyCode "Uruguayan Peso" "UYU" 858 2
Add-CurrencyCode "Uzbekistan Som" "UZS" 860 2
Add-CurrencyCode "Samoan Tala" "WST" 882 2
Add-CurrencyCode "Yemeni Rial" "YER" 886 0
Add-CurrencyCode "Zambian Kwacha" "ZMW" 894 0
Add-CurrencyCode "New Taiwan Dollar" "TWD" 901 1
Add-CurrencyCode "Venezuelan Bolivar Soberano" "VES" 928 2
Add-CurrencyCode "South Sudanese Pound" "STN" 930 2
Add-CurrencyCode "Zimbabwean Dollar" "ZWL" 932 2
Add-CurrencyCode "Turkmenistan Manat" "TMT" 934 2
Add-CurrencyCode "Ghanaian Cedi" "GHS" 936 2
Add-CurrencyCode "Sudanese Pound" "SDG" 938 2
Add-CurrencyCode "Serbian Dinar" "RSD" 941 2
Add-CurrencyCode "Mozambican Metical" "MZN" 943 2
Add-CurrencyCode "Azerbaijani Manat" "AZN" 944 2
Add-CurrencyCode "Romanian Leu" "RON" 946 2
Add-CurrencyCode "Turkish Lira" "TRY" 949 2
Add-CurrencyCode "Cfa Franc Beac" "XAF" 950 0
Add-CurrencyCode "East Caribbean Dollar" "XCD" 951 2
Add-CurrencyCode "Cfa Franc Bceao" "XOF" 952 0
Add-CurrencyCode "Cfp Franc" "XPF" 953 0
Add-CurrencyCode "Surinamese Dollar" "SRD" 968 2
Add-CurrencyCode "Malagasy Ariary" "MGA" 969 0.7
Add-CurrencyCode "Afghan Afghani" "AFN" 971 2
Add-CurrencyCode "Tajikistani Somoni" "TJS" 972 2
Add-CurrencyCode "Angolan Kwanza" "AOA" 973 2
Add-CurrencyCode "Belarusian Ruble" "BYR" 974 0
Add-CurrencyCode "Bulgarian Lev" "BGN" 975 2
Add-CurrencyCode "Congolese Franc" "CDF" 976 2
Add-CurrencyCode "Bosnia And Herzegovina Convertible Mark" "BAM" 977 2
Add-CurrencyCode "Euro" "EUR" 978 2
Add-CurrencyCode "Ukrainian Hryvnia" "UAH" 980 2
Add-CurrencyCode "Georgian Lari" "GEL" 981 2
Add-CurrencyCode "Polish Złoty" "PLN" 985 2
Add-CurrencyCode "Brazilian Real" "BRL" 986 2

Write-Host

Add-Country "Argentina" 20.0 9
Add-Country "Bolivia" 20.0 9
Add-Country "Brazil" 20.0 9
Add-Country "Chile" 20.0 9
Add-Country "Colombia" 20.0 9
Add-Country "Ecuador" 20.0 9
Add-Country "French Guiana" 20.0 9
Add-Country "Guyana" 20.0 9
Add-Country "Paraguay" 20.0 9
Add-Country "Peru" 20.0 9
Add-Country "Suriname" 20.0 9
Add-Country "Uruguay" 20.0 9
Add-Country "Venezuela" 20.0 9

Write-Host

Add-Company "Test Company"