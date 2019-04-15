const Foo = { template: '<div>foo</div>' }
const Bar = { template: '<div>bar</div>' }
const User = { 
    template: '<div class="user">User:{{$route.params.id}} <router-view></router-view></div>',
    watch: {
        '$route' (to, from){
            //console.log(to, from)
        }
    },
    beforeRouteUpdate (to, from, next) {
        console.log('Change')
        next()
    }
 }
 const UserHome = {
     template: '<div>User Home</div>'
 }
 const UserProfile = {
     template: '<div>User Profile</div>'
 }
 const UserPosts = {
     template: '<div>User Posts  <button @click="goto">Go to User Profile</button></div>',
     methods: {
        goto(){
            this.$router.push('profile')
        }
     }
 }
const routes = [
    { path: '/foo', component: Foo },
    { path: '/bar', component: Bar },
    { 
        path: '/user/:id', 
        component: User,
        children: [
            { path: '', component: UserHome, meta: { requiresAuth: 4 } },
            { path: 'profile', component: UserProfile, meta: { requiresAuth: 2 }},
            { path: 'posts', component: UserPosts, meta: { requiresAuth: 3 }}
        ],
        meta: { requiresAuth: 1 }
    }
]

const router = new VueRouter({
    routes
})

router.beforeEach((to, from, next) => {
    console.log(to.matched)
    next()
})

const app = new Vue({
    router
}).$mount('#app')