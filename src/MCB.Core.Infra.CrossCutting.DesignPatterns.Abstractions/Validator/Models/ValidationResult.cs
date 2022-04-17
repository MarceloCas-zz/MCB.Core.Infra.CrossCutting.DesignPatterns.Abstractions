﻿using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Validator.Enums;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Validator.Models
{
    public class ValidationResult
    {
        // Fields
        private readonly List<ValidationMessage> _validationMessageCollection;

        // Properties
        public IEnumerable<ValidationMessage> ValidationMessageCollection => _validationMessageCollection.AsReadOnly();
        public bool HasValidationMessage => _validationMessageCollection.Count > 0;
        public bool HasError => _validationMessageCollection.Any(q => q.ValidationMessageType == ValidationMessageType.Error);

        // Constructors
        public ValidationResult()
        {
            _validationMessageCollection = new List<ValidationMessage>();
        }
        public ValidationResult(ICollection<ValidationMessage> validationMessageCollection)
        {
            /*
             * This class receive a collection of ValidationMessage in constructor for can't add new ValidationMessage after instanciation
             */
            _validationMessageCollection = validationMessageCollection.ToList();
        }
    }
}
