---
description: Essential DataAnnotations attributes in .NET for model validation.
---

# Essential DataAnnotations Attributes in .NET validation

- **[CreditCard]**
  - Validates that the property has a valid credit card format.
  - Example: `[CreditCard] public string CardNumber { get; set; }`

- **[EmailAddress]**
  - Validates that the property contains a valid email address format.
  - Example: `[EmailAddress] public string Email { get; set; }`

- **[StringLength(max)]**
  - Ensures the string length does not exceed the specified maximum (`max`) characters.
  - Example: `[StringLength(50)] public string Name { get; set; }`

- **[MinLength(min)]**
  - Requires the collection to have at least the specified minimum (`min`) number of items.
  - Example: `[MinLength(2)] public List<string> Tags { get; set; }`

- **[Phone]**
  - Validates that the property has a valid phone number format.
  - Example: `[Phone] public string PhoneNumber { get; set; }`

- **[Range(min, max)]**
  - Validates that the property value is between the specified `min` and `max` values.
  - Example: `[Range(1, 100)] public int Age { get; set; }`

- **[RegularExpression(regex)]**
  - Validates that the property matches the specified regular expression (`regex`) pattern.
  - Example: `[RegularExpression(@"\d{4}-\d{4}")] public string Code { get; set; }`

- **[Url]**
  - Validates that the property contains a valid URL format.
  - Example: `[Url] public string Website { get; set; }`

- **[Required]**
  - Ensures the property is not null or empty.
  - Example: `[Required] public string Username { get; set; }`

- **[Compare("OtherProperty")]**
  - Confirms that two properties have the same value, often used for fields like passwords and their confirmations.
  - Example: `[Compare("Password")] public string ConfirmPassword { get; set; }`

For more detailed information and additional attributes, refer to the official Microsoft documentation: [DataAnnotations in ASP.NET Core](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations).
