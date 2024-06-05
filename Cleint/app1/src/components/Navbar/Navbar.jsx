import React, { useContext } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { UserContext } from '../../Context/UserContext'
import { Fragment } from 'react'
import Logo from '../../Assets/logo.png'
import { Disclosure, Menu, Transition } from '@headlessui/react'
import { Bars3Icon, XMarkIcon } from '@heroicons/react/24/outline'

const navigation = [
  { name: 'Home', href: '', current: true },
  { name: 'search', href: 'search', current: false },
  { name: 'Wishlist', href: 'wishlist', current: false },
  { name: 'AboutUS', href: 'aboutus', current: false },
]

function classNames(...classes) {
  return classes.filter(Boolean).join(' ')
}

export default function Navbar() {
 let {userToken,setUserToken}= useContext(UserContext)
 const nav=useNavigate()

let navigate=useNavigate()
function logout(){
  localStorage.removeItem('userToken')
  setUserToken(null)
  nav('/login')
} 
  return   <>
        {userToken?
          <Disclosure as="nav" className="bg-gray-800 fixed  z-20 w-full top-0 ">
          {({ open }) => (
            <>
              <div className="mx-auto max-w-8xl px-2  sm:px-6 lg:px-12 bg-slate-500 ">
                <div className="relative flex h-20 items-center justify-between">
                  <div className="absolute inset-y-0 left-0 flex items-center md:hidden">
                    {/* Mobile menu button */}
                    {userToken?
                    <Disclosure.Button className=" relative inline-flex items-center justify-center rounded-md p-2 text-gray-400 hover:bg-gray-700 hover:text-white focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white">
                      <span className="absolute -inset-0.5" />
                      <span className="sr-only">Open main menu</span>
                      {open ? (
                        <XMarkIcon className="block h-6 w-6" aria-hidden="true" />
                      ) : (
                        <Bars3Icon className="block h-6 w-6" aria-hidden="true" />
                      )}
                    </Disclosure.Button>
                     :
                     <></>
                  }
                  </div>
                 
                  <div className="flex flex-1 items-center justify-center md:justify-start sm:items-stretch">
                    <div className="flex flex-shrink-0 items-center  text-4xl">
                      <img
                        className="h-16 w-auto"
                        src={Logo}
                        alt="Your Company"
                      />
                      <h1></h1>
                    </div>
                    {userToken ? 
                      <div className="hidden  xl:ml-16 md:flex justify-center items-center ">
                      <div className="flex space-x-4 sm:ml-28  xl:ml-96 lg:ml-64 md:ml-40">
                        {navigation.map((item) => (
                          <Link
                            key={item.name}
                            to={item.href}
                            className={classNames(
                              item.current ? 'bg-gray-900 text-white' : 'text-gray-300 hover:bg-gray-700 hover:text-white',
                              'rounded-md px-3 py-2 text-sm font-medium'
                            )}
                            aria-current={item.current ? 'page' : undefined}
                          >
                            {item.name}
                          </Link>
                        ))}
                      </div>
                      </div>
                      :<></>
                    }
                  </div>
                                
                  {userToken ? 
             
                  <>
                  <div className="absolute inset-y-0 right-0 flex items-center pr-2 sm:static sm:inset-auto sm:ml-6 sm:pr-0">
                    {/* <button
                      type="button"
                      className="relative rounded-full bg-gray-800 p-1 text-gray-400 hover:text-white focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-800"
                    >
                      <span className="absolute -inset-1.5" />
                      <span className="sr-only">View notifications</span>
                      <BellIcon className="h-6 w-6" aria-hidden="true" />
                    </button> */}
    
                    {/* Profile dropdown */}
    
                    <Menu as="div" className="relative ml-3">
                      <div>
                        <Menu.Button className="relative flex rounded-full bg-gray-800 text-sm focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-800">
                          <span className="absolute -inset-1.5" />
                          <span className="sr-only">Open user menu</span>
                          <img
                            className="h-8 w-8 rounded-full"
                            src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                            alt=""
                          />
                        </Menu.Button>
                      </div>
                      <Transition
                        as={Fragment}
                        enter="transition ease-out duration-100"
                        enterFrom="transform opacity-0 scale-95"
                        enterTo="transform opacity-100 scale-100"
                        leave="transition ease-in duration-75"
                        leaveFrom="transform opacity-100 scale-100"
                        leaveTo="transform opacity-0 scale-95"
                      >
                        <Menu.Items className="absolute right-0 z-10 mt-2 w-48 origin-top-right rounded-md bg-white py-1 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                          <Menu.Item>
                            {({ active }) => (
                              <a
                                href="#"
                                className={classNames(active ? 'bg-gray-100' : '', 'block px-4 py-2 text-sm text-gray-700 cursor-pointer')}
                              >
                                Your Profile
                              </a>
                            )}
                          </Menu.Item>
                                <Menu.Item>
                            {({ active }) => (
                              <a
                                href="#"
                                onClick={()=>logout()}
                                className={classNames(active ? 'bg-gray-100' : '', 'block px-4 py-2 text-sm text-gray-700')}
                              >
                                Sign out
                              </a>
                            )}
                          </Menu.Item>
                        </Menu.Items>
                      </Transition>
                    </Menu>
                  </div>
                  
                  </>
                  :
                  <></>
                }
                </div>
              </div>
    
              <Disclosure.Panel className="md:hidden">
                <div className="space-y-1 px-2 pb-3 pt-2">
                  {navigation.map((item) => (
                  
                    <Disclosure.Button
                      key={item.name}
                      as={Link}
                      to={item.href}
                      className={classNames(
                        item.current ? 'bg-gray-900 text-white' : 'text-gray-300 hover:bg-gray-700 hover:text-white',
                        'block rounded-md px-3 py-2 text-base font-medium'
                      )}
                      aria-current={item.current ? 'page' : undefined}
                    >
                      {item.name}
                    </Disclosure.Button>
                  ))}
                </div>
              </Disclosure.Panel>
            </>
          )}
        </Disclosure>
        :
        <></>
        }
  



{/* <nav className="navbar navbar-expand-sm navbar-light bg-light">
    <div className="container">
    <a className="navbar-brand" href='' >Navbar</a>
    <button className="navbar-toggler d-lg-none" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavId" aria-controls="collapsibleNavId"
      aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>
    <div className="collapse navbar-collapse" id="collapsibleNavId">
      {userToken?
      <ul className="navbar-nav me-auto mt-2 mt-lg-0">
        <li className="nav-item">
          <Link className="nav-link" to="">Home</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="search">Search</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="aboutUs">About Us</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="contactUs">Contact Us</Link>
        </li>
      </ul>
      :
      ""
      }
      <ul className="navbar-nav ms-auto mt-2 mt-lg-0">
        {userToken?
        <li className="nav-item">
          <a className="nav-link pointer"onClick={()=>logout()} >Log Out</a>
        </li>
        
        :

<>
          <li className="nav-item">
          <Link className="nav-link" to="register">Register</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="login">Log in</Link>
        </li>
</>
    
        }
      </ul>
 
     
    </div>
  </div>
</nav> */}

  </>
}
