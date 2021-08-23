using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.Exceptions.Domain.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Tags;
using soa.qa.model.Tags;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Tags
{
    public class CreateTagProcessor : ICreateTagProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly ITagRepository _tagRepository;
        private readonly IAutoMapper _autoMapper;

        public CreateTagProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
          ITagRepository tagRepository)
        {
            _uOf = uOf;
            _tagRepository = tagRepository;
            _autoMapper = autoMapper;
        }

        private void MakeTagPersistent(Tag tagToBeMadePersistence)
        {
            _tagRepository.Save(tagToBeMadePersistence);
            _uOf.Commit();
        }

        private void ThrowExcIfThisTagAlreadyExist(Tag tagToBeCreated)
        {
            var tagRetrieved = _tagRepository.FindTagByTitle(tagToBeCreated.Title);
            if (tagRetrieved != null)
            {
                throw new TagAlreadyExistsException(tagToBeCreated.Title,
                  tagRetrieved.GetBrokenRulesAsString());
            }
        }

        private TagUiModel ThrowExcIfTagWasNotBeMadePersistent(Tag tagToBeCreated)
        {
            var retrievedTag = _tagRepository.FindTagByTitle(tagToBeCreated.Title);
            if (retrievedTag != null)
                return _autoMapper.Map<TagUiModel>(retrievedTag);
            throw new TagDoesNotExistAfterMadePersistentException(retrievedTag.Title);
        }

        private void ThrowExcIfTagCannotBeCreated(Tag tagToBeCreated)
        {
            bool canBeCreated = !tagToBeCreated.GetBrokenRules().Any();
            if (!canBeCreated)
                throw new InvalidTagException(tagToBeCreated.GetBrokenRulesAsString());
        }

        public Task<TagUiModel> CreateTagAsync(TagForCreationUiModel newTagUiModel)
        {
            var response =
              new TagUiModel()
              {
                  Message = "START_CREATION"
              };

            if (newTagUiModel == null)
            {
                response.Message = "ERROR_INVALID_Tag_MODEL";
                return Task.Run(() => response);
            }

            try
            {
                var tagToBeCreated = new Tag();

                tagToBeCreated.InjectWithInitialAttributes(newTagUiModel);

                ThrowExcIfTagCannotBeCreated(tagToBeCreated);
                ThrowExcIfThisTagAlreadyExist(tagToBeCreated);

                Log.Debug(
                  $"Create Tag: {newTagUiModel.Title}" +
                  "--CreateTag--  @NotComplete@ [CreateTagProcessor]. " +
                  "Message: Just Before MakeItPersistence");

                MakeTagPersistent(tagToBeCreated);

                Log.Debug(
                  $"Create Tag: {newTagUiModel.Title}" +
                  "--CreateTag--  @NotComplete@ [CreateTagProcessor]. " +
                  "Message: Just After MakeItPersistence");
                response = ThrowExcIfTagWasNotBeMadePersistent(tagToBeCreated);
                response.Message = "SUCCESS_CREATION";
            }
            catch (InvalidTagException e)
            {
                response.Message = "ERROR_INVALID_TAG_MODEL";
                Log.Error(
                  $"Create Tag: {newTagUiModel.Title}" +
                  $"Error Message:{response.Message}" +
                  "--CreateTag--  @NotComplete@ [CreateTagProcessor]. " +
                  $"Broken rules: {e.BrokenRules}");
            }
            catch (TagAlreadyExistsException ex)
            {
                response.Message = "ERROR_TAG_ALREADY_EXISTS";
                Log.Error(
                  $"Create Tag: {newTagUiModel.Title}" +
                  $"Error Message:{response.Message}" +
                  "--CreateTag--  @fail@ [CreateTagProcessor]. " +
                  $"@innerfault:{ex?.Message} and {ex?.InnerException}");
            }
            catch (TagDoesNotExistAfterMadePersistentException exx)
            {
                response.Message = "ERROR_TAG_NOT_MADE_PERSISTENT";
                Log.Error(
                  $"Create Tag: {newTagUiModel.Title}" +
                  $"Error Message:{response.Message}" +
                  "--CreateTag--  @fail@ [CreateTagProcessor]." +
                  $" @innerfault:{exx?.Message} and {exx?.InnerException}");
            }
            catch (Exception exxx)
            {
                response.Message = "UNKNOWN_ERROR";
                Log.Error(
                  $"Create Tag: {newTagUiModel.Title}" +
                  $"Error Message:{response.Message}" +
                  $"--CreateTag--  @fail@ [CreateTagProcessor]. " +
                  $"@innerfault:{exxx.Message} and {exxx.InnerException}");
            }
            return Task.Run(() => response);
        }
    }
}
