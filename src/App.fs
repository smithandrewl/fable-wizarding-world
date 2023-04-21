module App

open Elmish
open Elmish.React

open Feliz
open Feliz.Router

open State.Store
open State.Reducers
open Pages.LoginPage

let view (model: Model) (dispatch: Msg -> Unit) =
    let currentPage =
        match model.currentUrl with
        | [] -> loginPage(model, dispatch)
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
    
Program.mkProgram  (fun _ -> initModel, Cmd.none) update view
|> Program.withReactSynchronous "root"
|> Program.run