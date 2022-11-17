extern {
    fn CacheGet(key: i32) -> i32;
    fn CachePut(key: i32, val: i32);
}

fn main() {
    unsafe {
        println!("Starting Ignite client...");

        let key = 42;
        CachePut(key, key + 1);

        let res = CacheGet(key);
        println!("Result from cache: {}", res);
    }
}
