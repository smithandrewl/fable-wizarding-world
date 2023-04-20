module State.Store

open Feliz
open Feliz.Router
open Elmish
open Elmish.React

open Feliz
open Feliz.Router

open Feliz.MaterialUI
open Feliz.MaterialUI.menu
open Fable.React


type Page =
    | Home
    | NotFound
    
type LoginState =
    | WaitingForInput
    | LoginFailed
    | LoginSucceeded
    

type Model = {
    username:   string
    password:   string
    loginState: LoginState
    currentUrl: string list
}
    
let initModel = {
    username = ""
    password = ""
    loginState = WaitingForInput
    currentUrl = Router.currentUrl() 
}