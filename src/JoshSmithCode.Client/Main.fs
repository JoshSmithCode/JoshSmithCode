module JoshSmithCode.Client.Main

open System
open Elmish
open Bolero
open Bolero.Html
open Bolero.Html.attr
open Helpers
open Bolero.Remoting
open Bolero.Remoting.Client
open Bolero.Templating.Client

/// Routing endpoints definition.
type Page =
    | [<EndPoint "/">] Home

/// The Elmish application's model.
type Model =
    {
        page: Page
    }

let initModel =
    {
        page = Home
    }

/// The Elmish application's update messages.
type Message =
    | SetPage of Page

let update message model =
    match message with
    | SetPage page ->
        { model with page = page }, Cmd.none

/// Connects the routing system to the Elmish application.
let router = Router.infer SetPage (fun model -> model.page)

type Main = Template<"wwwroot/main.html">

let homePage model dispatch =
    Main.Home().Elt()

let myNav =
    nav   
        [ className "navbar navbar-expand navbar-dark" ]
        [ 
            div
                [ className "navbar-brand" ]
                [
                    div
                        [ className "nav-item text-primary" ]
                        [ text "JoshSmithCode" ]
                ]
            div
                [ className "navbar-nav mr-auto" ]
                [
                    a
                        [ 
                            className "nav-item nav-link" 
                            href "/"
                        ]
                        [ text "Home" ]
                    a 
                        [ 
                            className "nav-item nav-link" 
                            href "/"
                        ]
                        [ text "Projects" ]
                    a 
                        [ 
                            className "nav-item nav-link" 
                            href "/"
                        ]
                        [ text "Contact" ]
                ]
            
        ]


let myIntro = 
    div
        [ className "container" ]
        [ 
            div
                [
                    className "d-flex justify-content-center align-items-center text-center px-5" 
                    attr.style "height: calc(50vh); font-size: 1.5em;"
                ]
                [
                    p
                        [ className "text-white" ]  
                        [ 
                            text "Hi, my name is "
                            strong
                                []
                                [ text "Josh" ]
                            text " and I'm a web devleoper. I " 
                            strong
                                [ className "text-primary" ]
                                [ text "LOVE" ]
                            text " what I do."
                        ]
                ]
        ]

let mySkills = 
    div
        [ className "container-fluid bg-light" ]
        [
            div
                [ className "container py-4" ]
                [
                    div
                        [ className "row" ]
                        [
                            div
                                [ className "col-12" ]
                                [
                                    div
                                        [ className "card border-primary" ]
                                        [
                                            div
                                                [ className "card-header bg-primary text-white" ]
                                                [ text "My Experience" ]
                                            div
                                                [ className "card-body" ]
                                                [ 
                                                    p
                                                        []
                                                        [ text "
                                                            I have more than 7 years experience building web applications using
                                                            a variety of technologies. I am a full stack developer, working on everything
                                                            from styles and UI to servers, API's and databasing. Most of my experience is 
                                                            in PHP, JavaScript, Elm and MySQL, but I love learning and I'm always interested in 
                                                            picking up new skills. 
                                                        " 
                                                        ]
                                                ]
                                        ]
                                ]
                            div
                                [ className "col-12" ]
                                [
                                    div
                                        [ className "row mt-4" ]
                                        [
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fab fa-php skill-icon text-primary mr-2" ] []
                                                    Html.span [ className "" ] [ text "PHP" ]
                                                ]
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fas fa-heart skill-icon text-primary mr-2" ] []
                                                    Html.span [ className "" ] [ text "Elm" ]
                                                ]
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fab fa-react skill-icon text-primary mr-2" ] []
                                                    Html.span [ className "" ] [ text "React" ]
                                                ]
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fas fa-question-circle skill-icon text-primary" ] []
                                                    Html.span [ className "" ] [ text "F#" ]
                                                ]
                                            div [ className "w-100 d-md-none d-lg-none my-2" ] []
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fas fa-database skill-icon text-primary mr-2" ] []
                                                    Html.span [ className "" ] [ text "MySQL" ]
                                                ]
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fab fa-html5 skill-icon text-primary mr-2" ] []
                                                    Html.span [ className "" ] [ text "HTML5" ]
                                                ]
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fab fa-css3 skill-icon text-primary mr-2" ] []
                                                    Html.span [ className "" ] [ text "CSS" ]
                                                ]
                                            div 
                                                [ className "d-flex align-items-center col" ]
                                                [
                                                    Html.span [ className "fab fa-js skill-icon text-primary mr-2" ] []
                                                    small [ className "" ] [ text "JavaScript" ]
                                                ]
                                        ]
                                ]
                        ]
                ]
        ]


let myHome =
    concat
        [
            myIntro
            mySkills
        ]

let view model dispatch =
    concat
        [ 
            myNav
            myHome
        ]




type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkProgram (fun _ -> initModel, Cmd.none) update view
        |> Program.withRouter router
#if DEBUG
        |> Program.withHotReload
#endif
