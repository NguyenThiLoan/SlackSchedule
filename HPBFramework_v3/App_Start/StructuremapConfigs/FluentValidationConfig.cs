using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using StructureMap;
using HPBFramework.FluentValidation;

internal class FluentValidationConfig
{
    public static void Register(IContainer container)
    {
        ModelValidatorProviders.Providers.Clear();
        DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        var fvmvp = new FluentValidationModelValidatorProvider(new FluentValidatorFactory(container))
                    {
                        AddImplicitRequiredValidator = false,
                    };

        FluentValidationModelValidationFactory validationFactory = (metadata, context, rule, validator) => new RemoteFluentValidationPropertyValidator(metadata, context, rule, validator);
        FluentValidationModelValidatorProvider.Configure(x => x.Add(typeof(RemoteValidator), validationFactory));
        fvmvp.Add(typeof(RemoteValidator), validationFactory);
        ModelValidatorProviders.Providers.Add(fvmvp);

    }
}

public class FluentValidatorFactory : ValidatorFactoryBase
{
    private readonly IContainer _container;

    public FluentValidatorFactory(IContainer container)
    {
        this._container = container;
    }

    public override IValidator CreateInstance(Type validatorType)
    {
        var validator = (IValidator)_container.TryGetInstance(validatorType);
        return validator;
    }
}