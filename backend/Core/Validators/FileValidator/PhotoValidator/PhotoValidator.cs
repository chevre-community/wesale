using Core.Constants.File;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators.FileValidator.PhotoValidator
{
    public class PhotoValidator : AbstractValidator<IPhotoProperty>
    {
        private readonly ITranslationService _translationService;

        private long MaxUploadSize { get; set; }
        public string[] ProvidedContentTypes { get; set; }

        //Error messages
        private string MAX_UPLOAD_SIZE_MESSAGE { get; set; }
        private string ALLOWED_FILE_TYPES_MESSAGE { get; set; }

        public PhotoValidator(ITranslationService translationService, long maxUploadSize, params string[] providedContentTypes)
        {
            _translationService = translationService;
            MaxUploadSize = maxUploadSize;
            ProvidedContentTypes = providedContentTypes;

            FulfillErrorMessages();
            IntegrateRules();
        }

        private void FulfillErrorMessages()
        {
            MAX_UPLOAD_SIZE_MESSAGE = _translationService.GetTranslationByKey("MaxUploadSize");
            ALLOWED_FILE_TYPES_MESSAGE = _translationService.GetTranslationByKey("AllowedFileTypes");
        }

        private void IntegrateRules()
        {
            RuleFor(P => P.Photo)
                .Cascade(CascadeMode.Stop)

                .Must(photo => photo.Length <= MaxUploadSize)
                .WithMessage(MAX_UPLOAD_SIZE_MESSAGE.Replace("{}", (MaxUploadSize / StorageUnits.Megabyte).ToString()))

                .Must(photo => ProvidedContentTypes.Contains(photo.ContentType))
                .WithMessage(ALLOWED_FILE_TYPES_MESSAGE.Replace("{}", ContentTypeHelper.GetExtensionFromMimetypes(ProvidedContentTypes)));
        }


    }
}
