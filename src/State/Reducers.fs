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
                loginSection = WaitingForInput(username, password)
        }
    | LoginSubmission ->
        match model.loginSection with
        | Empty                            -> model // If the user didn't fill out the info and hit submit do nothing
        | LoginSectionState.LoginSucceeded -> model // If the user is already logged in do nothing
        | LoginSectionState.LoginFailed (username, password) -> // If a login attempt failed and this is a new submission
                                                                // Switch the state to waiting for input
            {
                model with loginSection = LoginSectionState.WaitingForInput(username, password)
            }
        | WaitingForInput(username, password) ->
            if username = "a" && password = "a" then
                {
                    model with loginSection = LoginSectionState.LoginSucceeded 
                    
                }
            else
                {
                    model with loginSection = LoginSectionState.LoginFailed(username, password)
                }
                
    | UrlChanged(page) -> { model with currentUrl =  page }