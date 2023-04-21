module App

open Elmish
open Elmish.React

open Feliz
open Feliz.Router

open Feliz.MaterialUI
open Feliz.MaterialUI.menu
open Fable.React

open State.Store
open State.Reducers

open Components.Login
    

let app = React.functionComponent( fun (model: Model, dispatch) ->
    Mui.container  [
        container.maxWidth.xs
        
        prop.children [      
            loginComponent (model, dispatch)
            
            Html.h1 [
                prop.text 
                    (match model.loginSection.state with
                    | LoginState.WaitingForInput -> ""
                    | LoginState.LoginFailed     -> "Login Failed"
                    | LoginState.LoginSucceeded  -> "Login Succeeded")
            ]
        ]
    ]
)


let view (model: Model) (dispatch: Msg -> Unit) =
    let currentPage =
        match model.currentUrl with
        | [] -> app(model, dispatch)
        | _ ->
            Html.div [
                Html.h1 "404 not found"
            ]
    
    React.router [
        router.onUrlChanged (UrlChanged >> dispatch)
        router.children [
            currentPage
        ]
    ]
    
Program.mkSimple  (fun _ -> initModel) update view
|> Program.withReactSynchronous "root"
|> Program.run