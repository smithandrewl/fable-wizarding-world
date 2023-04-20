module State.Reducers

open State.Store

type Msg =
    | FormUpdated     of string * string
    | LoginSubmission

let update msg (model: Model) =
    match msg with
    | FormUpdated(username, password) ->
        {
            model with
                username = username
                password = password
        }
    | LoginSubmission ->
        if model.username = "a" && model.password = "a" then
            { model with loginState = LoginState.LoginSucceeded }
        else
            { model with loginState = LoginState.LoginFailed }