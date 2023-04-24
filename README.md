# AspNetWebApi Examples

Here 2 examples how an ApiKey can be implemented, as soon as FluentValidation is used, the middleware logic should be used in any case!

## ApiKeyViaActionFilter (IAsyncActionFilter)
If you use FluentValidation, the ApiKey filter is used after the validation logic, which means an attacker can trigger queries to the database without an ApiKey - we want to prevent this at all costs.

## ApiKeyViaMiddleware (UseMiddleware)
The middleware takes effect before the validation logic is executed. This is the way that protects our database.
