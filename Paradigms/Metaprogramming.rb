class LibraryItem
  attr_accessor :title, :author
end

# Use metaprogramming to dynamically add methods to the class
LibraryItem.class_eval do
  def display_info
    puts "#{title} by #{author}"
  end
end

book = LibraryItem.new
book.title = "Frankenstein"
book.author = "Mary Shelley"
book.display_info

# Define a method that generates other methods
def define_checkout_method(item_type)
  define_method("checkout_#{item_type}") do |duration|
    puts "Checking out #{item_type} for #{duration} days."
  end
end

# Use the method generator for different types of library items
class Library
  [:book, :dvd, :magazine].each do |item|
    define_checkout_method(item)
  end
end

library = Library.new
library.checkout_book(14)
library.checkout_dvd(7)
library.checkout_magazine(2)

# Demonstrate method_missing for flexible attribute access
class FlexibleItem
  def initialize(attributes = {})
    @attributes = attributes
  end

  def method_missing(name, *args)
    if @attributes.has_key?(name)
      @attributes[name]
    else
      super
    end
  end

  def respond_to_missing?(name, include_private = false)
    @attributes.has_key?(name) || super
  end
end

# Create a flexible item and access attributes dynamically
flexible_book = FlexibleItem.new(title: "Darkly Dreaming Dexter", author: "Jeff Lindsay", genre: "Suspense")
puts flexible_book.title
puts flexible_book.genre

# Introspection
puts LibraryItem.instance_methods(false)  # Show methods defined in the LibraryItem class
puts Library.instance_methods(false)      # Show methods defined in the Library class