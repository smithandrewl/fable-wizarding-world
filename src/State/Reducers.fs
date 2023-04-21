module State.Reducers

open State.Store
open Elmish

type Msg =
    | LoginFormUpdated of string * string
    | LoginSubmission
    | LoginSucceeded
    | LoginFailed
    | UrlChanged of string list

let update msg (model: Model) =
    match msg with
    | LoginFormUpdated(username, password) ->
        {
            model with
                loginSection =
                    { model.loginSection with username = username; password = password }
        }, Cmd.none
    | LoginSubmission ->
        if model.loginSection.username = "a" && model.loginSection.password = "a" then
            {
                model with loginSection = { model.loginSection with state = LoginState.LoginSucceeded }
                
            }, Cmd.none
        else
            {
                model with loginSection = { model.loginSection with state = LoginState.LoginFailed }
            }, Cmd.none
    | UrlChanged(page) -> { model with currentUrl =  page }, Cmd.none