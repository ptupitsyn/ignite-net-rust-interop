fn main() {
    println!("cargo:rustc-link-search=native=../../dotnet/libignite/publish");
    println!("cargo:rustc-link-lib=ignite");
}
