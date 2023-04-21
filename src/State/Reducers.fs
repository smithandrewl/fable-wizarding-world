module State.Reducers

open State.Store

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
        }
    | LoginSubmission ->
        match model.loginSection.state with
        | WaitingForInput -> // If a login attempt failed and this is a new submission
            if model.loginSection.username = "a" && model.loginSection.password = "a" then
                {
                    model with loginSection = { model.loginSection with state = LoginState.LoginSucceeded }
                    
                }
            else
                {
                    model with loginSection = { model.loginSection with state = LoginState.LoginFailed }
                }
        | LoginState.LoginSucceeded -> model
        | LoginState.LoginFailed -> model
                
    | UrlChanged(page) -> { model with currentUrl =  page }