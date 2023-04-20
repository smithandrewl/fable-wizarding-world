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
    
type LoginSectionState =
    | Empty
    | WaitingForInput of username:string * password: string
    | LoginFailed     of username:string * password: string
    | LoginSucceeded
    
type Model = {
    loginSection: LoginSectionState
    currentUrl: string list
}
    
let initModel = {
    loginSection = Empty
    currentUrl = Router.currentUrl() 
}