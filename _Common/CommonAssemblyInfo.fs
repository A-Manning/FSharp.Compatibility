(*  OCaml Compatibility Library for F#
    (FSharpx.Compatibility.OCaml)

    Copyright � 2012 Jack Pappas (github.com/jack-pappas)

    This code is available under the Apache 2.0 license.
    See the LICENSE file for the complete text of the license. *)

(* NOTE :   This file must be the last file in the F# project's build order. *)

/// Defines assembly-level attributes common to all projects in the solution.
module internal CommonAssemblyInfo

open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

// Disable warning about empty function bodies.
#nowarn "988"

/// <summary>A subset of the conditional compilation symbols
/// specified when this assembly was compiled.</summary>
/// <remarks>Used for diagnostics purposes, e.g., to mark traced
/// and debug builds.</remarks>
let [<Literal>] private assemblyConfig =
    #if DEBUG
    #if TRACE
    "DEBUG;TRACE"
    #else
    "DEBUG"
    #endif
    #else
    #if TRACE
    "TRACE"
    #else
    ""
    #endif
    #endif

// General information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[<assembly: AssemblyConfiguration(assemblyConfig)>]
//[<assembly: AssemblyTrademark("")>]
//[<assembly: AssemblyCulture("")>]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[<assembly: ComVisible(false)>]

// Version information
[<assembly: AssemblyVersion("0.1.0.0")>]
[<assembly: AssemblyFileVersion("0.1.0.0")>]
[<assembly: AssemblyInformationalVersion("0.1.0.0")>]

// Only allow types derived from System.Exception to be thrown --
// any other types should be automatically wrapped.
[<assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)>]

(*  F# considers modules which only contain attributes to be empty;
    so, we appease the compiler by adding an empty function. *)
do ()