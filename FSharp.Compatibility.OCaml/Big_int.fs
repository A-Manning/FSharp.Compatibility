﻿(*

Copyright 2005-2009 Microsoft Corporation
Copyright 2012 Jack Pappas

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*)

// References:
// http://caml.inria.fr/pub/docs/manual-ocaml/libref/Big_int.html

/// Operations on arbitrary-precision integers.
/// Big integers (type big_int) are signed integers of arbitrary size.
[<CompilerMessage(
    "This module is for ML compatibility. \
    This message can be disabled using '--nowarn:62' or '#nowarn \"62\"'.",
    62, IsHidden = true)>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FSharp.Compatibility.OCaml.Big_int

open System.Collections.Generic
open System.Numerics


/// The type of big integers.
type big_int = bigint

/// The big integer 0.
let zero_big_int : big_int = BigInteger.Zero

/// The big integer 1.
let unit_big_int : big_int = BigInteger.One


(*** Arithmetic operations ***)

/// Unary negation.
let inline minus_big_int (x : big_int) : big_int =
    BigInteger.Negate x

/// Absolute value.
let inline abs_big_int (x : big_int) : big_int =
    BigInteger.Abs x

/// Addition.
let inline add_big_int (x : big_int) (y : big_int) =
    BigInteger.Add (x, y)

/// Successor (add 1).
let inline succ_big_int (x : big_int) : big_int =
    BigInteger.Add (x, BigInteger.One)

/// Addition of a small integer to a big integer.
let inline add_int_big_int (x : int) (y : big_int) : big_int =
    BigInteger.Add (BigInteger (x), y)

/// Subtraction.
let inline sub_big_int (x : big_int) (y : big_int) : big_int =
    BigInteger.Subtract (x, y)

/// Predecessor (subtract 1).
let inline pred_big_int (x : big_int) : big_int =
    BigInteger.Subtract (x, BigInteger.One)

/// Multiplication of two big integers.
let inline mult_big_int (x : big_int) (y : big_int) : big_int =
    BigInteger.Multiply (x, y)

/// Multiplication of a big integer by a small integer.
let inline mult_int_big_int (x : int) (y : big_int) : big_int =
    BigInteger.Multiply (BigInteger (x), y)

/// Return the square of the given big integer.
let inline square_big_int (x : big_int) : big_int =
    BigInteger.Multiply (x, x)

/// sqrt_big_int a returns the integer square root of a, that is, the largest big integer r such that r * r <= a.
/// Raise Invalid_argument if a is negative.
let (*inline*) sqrt_big_int (a : big_int) : big_int =
    raise <| System.NotImplementedException "Big_int.sqrt_big_int"

/// Euclidean quotient of two big integers. This is the first result q of quomod_big_int.
let inline div_big_int (a : big_int) (b : big_int) : big_int =
    BigInteger.Divide (a, b)

/// Euclidean modulus of two big integers. This is the second result r of quomod_big_int.
let inline mod_big_int (a : big_int) (b : big_int) : big_int =
    BigInteger.Remainder (a, b)

/// Euclidean division of two big integers.
/// The first part of the result is the quotient, the second part is the remainder.
/// Writing (q,r) = quomod_big_int a b, we have a = q * b + r and 0 <= r < |b|.
/// Raise Division_by_zero if the divisor is zero.
let inline quomod_big_int (a : big_int) (b : big_int) : big_int * big_int =
    BigInteger.DivRem (a, b)

/// Greatest common divisor of two big integers.
let inline gcd_big_int (a : big_int) (b : big_int) : big_int =
    raise <| System.NotImplementedException "Big_int.gcd_big_int"


(*  Exponentiation functions.
    Return the big integer representing the first argument a raised to the power b (the second argument).
    Depending on the function, a and b can be either small integers or big integers.
    Raise Invalid_argument if b is negative. *)

//
let power_int_positive_int (x : int) (y : int) : big_int =
    raise <| System.NotImplementedException "Big_int.power_int_positive_int"

//
let power_big_int_positive_int (x : big_int) (y : int) : big_int =
    raise <| System.NotImplementedException "Big_int.power_big_int_positive_int"

//
let power_int_positive_big_int (x : int) (y : big_int) : big_int =
    raise <| System.NotImplementedException "Big_int.power_int_positive_big_int"

//
let power_big_int_positive_big_int (x : big_int) (y : big_int) : big_int =
    raise <| System.NotImplementedException "Big_int.power_big_int_positive_big_int"



(*** Comparisons and tests ***)

/// Return 0 if the given big integer is zero, 1 if it is positive, and -1 if it is negative.
let inline sign_big_int (x : big_int) : int =
    x.Sign

/// compare_big_int a b returns 0 if a and b are equal, 1 if a is greater than b, and -1 if a is smaller than b.
let inline compare_big_int (x : big_int) (y : big_int) : int =
    BigInteger.Compare (x, y)

(* Usual boolean comparisons between two big integers. *)
let inline eq_big_int (x : big_int) (y : big_int) : bool =
    x.Equals y
let inline le_big_int (x : big_int) (y : big_int) : bool =
    x <= y
let inline ge_big_int (x : big_int) (y : big_int) : bool =
    x >= y
let inline lt_big_int (x : big_int) (y : big_int) : bool =
    x < y
let inline gt_big_int (x : big_int) (y : big_int) : bool =
    x > y

/// Return the greater of its two arguments.
let inline max_big_int (x : big_int) (y : big_int) : big_int =
    BigInteger.Max (x, y)

/// Return the smaller of its two arguments.
let inline min_big_int (x : big_int) (y : big_int) : big_int =
    BigInteger.Min (x, y)

/// Return the number of machine words used to store the given big integer.
let num_digits_big_int (x : big_int) : int =
    raise <| System.NotImplementedException "Big_int.num_digits_big_int"


(*** Conversions to and from strings ***)

/// Return the string representation of the given big integer, in decimal (base 10).
let inline string_of_big_int (x : big_int) : string =
    x.ToString ()

let private digits: Map<char, big_int> =
    "0123456789ABCDEF"
    |> Seq.mapi (fun index char -> char, bigint index)
    |> Map.ofSeq

// Converts a string of base (b <= 16) to decimal bigint
let private of_base (b: int) (s: string): big_int =
    let aux (total: big_int) (c: char): big_int = 
        (total + Map.find c digits) * bigint b
    Seq.fold aux 0I s
    / big_int b

let private of_bin: string -> big_int = of_base 2 
let private of_oct: string -> big_int = of_base 8
let private of_hex: string -> big_int = of_base 16

/// Convert a string to a big integer, in decimal.
/// The string consists of an optional - or + sign, 
/// followed by an optional format specifier 
/// ("0x", "0o", "0b" for hex, octal, and binary respectively),
/// followed by one or several decimal digits.
let rec big_int_of_string (str : string) : big_int =
    if   str.StartsWith("-")
        then - big_int_of_string (str.Substring 1)
    elif str.StartsWith("+")
        then   big_int_of_string (str.Substring 1)
    elif str.StartsWith("0x")
        then of_hex <| str.Substring 2
    elif str.StartsWith("0o")
        then of_oct <| str.Substring 2
    elif str.StartsWith("0b")
        then of_bin <| str.Substring 2
    else
        BigInteger.Parse str

(*** Conversions to and from other numerical types ***)

// TODO



(*** Bit-oriented operations ***)

// TODO


